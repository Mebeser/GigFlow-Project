using AutoMapper;
using GigFlow.Application.Features.JobPostings.DTOs;
using GigFlow.Application.Repositories;
using MediatR;

namespace GigFlow.Application.Features.JobPostings.Queries.GetJobPostingById;

public class GetJobPostingByIdQueryHandler : IRequestHandler<GetJobPostingByIdQuery, GetJobPostingByIdDto>
{
    private readonly IJobPostingRepository _jobPostingRepository;
    private readonly IMapper _mapper;

    public GetJobPostingByIdQueryHandler(IJobPostingRepository jobPostingRepository, IMapper mapper)
    {
        _jobPostingRepository = jobPostingRepository;
        _mapper = mapper;
    }

    public async Task<GetJobPostingByIdDto> Handle(GetJobPostingByIdQuery request, CancellationToken cancellationToken)
    {
        var jobPosting = await _jobPostingRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetJobPostingByIdDto>(jobPosting);
    }
}
