using AutoMapper;
using GigFlow.Application.Features.JobPostings.DTOs;
using GigFlow.Application.Repositories;
using GigFlow.Application.Responses;
using MediatR;
using System.Linq;

namespace GigFlow.Application.Features.JobPostings.Queries.GetAllJobPostings;

public class GetAllJobPostingsQueryHandler : IRequestHandler<GetAllJobPostingsQuery, PaginatedResult<GetJobPostingListDto>>
{
    private readonly IJobPostingRepository _jobPostingRepository;
    private readonly IMapper _mapper;

    public GetAllJobPostingsQueryHandler(IJobPostingRepository jobPostingRepository, IMapper mapper)
    {
        _jobPostingRepository = jobPostingRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<GetJobPostingListDto>> Handle(GetAllJobPostingsQuery request, CancellationToken cancellationToken)
    {
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

        return new PaginatedResult<GetJobPostingListDto>(dtoList, totalCount, request.PageNumber, request.PageSize);
    }
}
