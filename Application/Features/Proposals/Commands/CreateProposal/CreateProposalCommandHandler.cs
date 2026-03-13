using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using MediatR;
using System.Linq;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.Proposals.Commands.CreateProposal;

public class CreateProposalCommandHandler : IRequestHandler<CreateProposalCommand, Guid>
{
    private readonly IProposalRepository _proposalRepository;
    private readonly IJobPostingRepository _jobPostingRepository;

    public CreateProposalCommandHandler(
        IProposalRepository proposalRepository,
        IJobPostingRepository jobPostingRepository)
    {
        _proposalRepository = proposalRepository;
        _jobPostingRepository = jobPostingRepository;
    }

    public async Task<Guid> Handle(CreateProposalCommand request, CancellationToken cancellationToken)
    {
        var jobPosting = await _jobPostingRepository.GetByIdAsync(request.JobPostingId);
        
        if (jobPosting == null)
            throw new NotFoundException("Job Posting", request.JobPostingId);

        if (jobPosting.Status == JobStatus.Cancelled)
            throw new Exception("Cannot send proposal to a cancelled job posting.");

        if (jobPosting.Deadline.HasValue && jobPosting.Deadline.Value < DateTime.UtcNow)
            throw new Exception("Deadline has passed for this job posting.");

        if (request.FreelancerId.HasValue)
        {
            var existingProposals = await _proposalRepository.GetAllAsync(p => p.JobPostingId == request.JobPostingId && p.FreelancerId == request.FreelancerId);
            if (existingProposals.Any())
            {
                throw new Exception("You have already submitted a proposal for this job posting.");
            }
        }

        var proposal = new Proposal
        {
            Id = Guid.NewGuid(),
            JobPostingId = request.JobPostingId,
            FreelancerId = request.FreelancerId,
            CoverLetter = request.CoverLetter,
            ProposedAmount = request.ProposedAmount,
            EstimatedDuration = request.EstimatedDuration,
            Status = ProposalStatus.Pending,
            CreatedDate = DateTime.UtcNow
        };

        await _proposalRepository.AddAsync(proposal);

        return proposal.Id;
    }
}
