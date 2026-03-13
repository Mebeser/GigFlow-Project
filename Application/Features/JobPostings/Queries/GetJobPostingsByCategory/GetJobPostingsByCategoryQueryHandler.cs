using AutoMapper;
using GigFlow.Application.Features.JobPostings.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.JobPostings.Queries.GetJobPostingsByCategory;

public class GetJobPostingsByCategoryQueryHandler : IRequestHandler<GetJobPostingsByCategoryQuery, List<GetJobPostingListDto>>
{
    private readonly IJobPostingRepository _jobPostingRepository;
    private readonly IMapper _mapper;

    public GetJobPostingsByCategoryQueryHandler(IJobPostingRepository jobPostingRepository, IMapper mapper)
    {
        _jobPostingRepository = jobPostingRepository;
        _mapper = mapper;
    }

    public async Task<List<GetJobPostingListDto>> Handle(GetJobPostingsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var jobPostings = await _jobPostingRepository.GetAllAsync(j => j.CategoryId == request.CategoryId);
        return _mapper.Map<List<GetJobPostingListDto>>(jobPostings);
    }
}
