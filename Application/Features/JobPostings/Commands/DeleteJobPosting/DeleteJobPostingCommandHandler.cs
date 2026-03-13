using GigFlow.Application.Repositories;
using MediatR;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.JobPostings.Commands.DeleteJobPosting;

public class DeleteJobPostingCommandHandler : IRequestHandler<DeleteJobPostingCommand, bool>
{
    private readonly IJobPostingRepository _jobPostingRepository;

    public DeleteJobPostingCommandHandler(IJobPostingRepository jobPostingRepository)
    {
        _jobPostingRepository = jobPostingRepository;
    }

    public async Task<bool> Handle(DeleteJobPostingCommand request, CancellationToken cancellationToken)
    {
        var jobPosting = await _jobPostingRepository.GetByIdAsync(request.Id);
        
        if (jobPosting == null)
            throw new NotFoundException("Job Posting", request.Id);

        await _jobPostingRepository.DeleteAsync(jobPosting);
        return true;
    }
}
