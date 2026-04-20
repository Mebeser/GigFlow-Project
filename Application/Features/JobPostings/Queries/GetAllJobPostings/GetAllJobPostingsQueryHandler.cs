using AutoMapper;
using GigFlow.Application.Features.JobPostings.DTOs;
using GigFlow.Application.Interfaces;
using GigFlow.Application.Repositories;
using GigFlow.Application.Responses;
using MediatR;

namespace GigFlow.Application.Features.JobPostings.Queries.GetAllJobPostings;

public class GetAllJobPostingsQueryHandler : IRequestHandler<GetAllJobPostingsQuery, PaginatedResult<GetJobPostingListDto>>
{
    private readonly IJobPostingRepository _jobPostingRepository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public GetAllJobPostingsQueryHandler(
        IJobPostingRepository jobPostingRepository, 
        IMapper mapper,
        ICacheService cacheService)
    {
        _jobPostingRepository = jobPostingRepository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<PaginatedResult<GetJobPostingListDto>> Handle(GetAllJobPostingsQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"jobpostings_{request.SearchTerm}_{request.CategoryId}_{request.PageNumber}_{request.PageSize}";

        var cached = await _cacheService.GetAsync<PaginatedResult<GetJobPostingListDto>>(cacheKey);
        if (cached != null) return cached;

        var jobPostings = await _jobPostingRepository.GetAllAsync();
        
        var query = jobPostings.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            query = query.Where(j => j.Title.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) || 
                                     j.Description.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));
        }

        if (request.CategoryId.HasValue)
        {
            query = query.Where(j => j.CategoryId == request.CategoryId.Value);
        }

        int totalCount = query.Count();

        var paginatedItems = query
            .OrderByDescending(j => j.CreatedDate)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var dtoList = _mapper.Map<List<GetJobPostingListDto>>(paginatedItems);

        var result = new PaginatedResult<GetJobPostingListDto>(dtoList, totalCount, request.PageNumber, request.PageSize);
        
        await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(5));

        return result;
    }
}