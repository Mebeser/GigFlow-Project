using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.Proposals.Commands.AcceptProposal;

public class AcceptProposalCommandHandler : IRequestHandler<AcceptProposalCommand, bool>
{
    private readonly IProposalRepository _proposalRepository;
    private readonly IContractRepository _contractRepository;
    private readonly IJobPostingRepository _jobPostingRepository;

    public AcceptProposalCommandHandler(
        IProposalRepository proposalRepository,
        IContractRepository contractRepository,
        IJobPostingRepository jobPostingRepository)
    {
        _proposalRepository = proposalRepository;
        _contractRepository = contractRepository;
        _jobPostingRepository = jobPostingRepository;
    }

    public async Task<bool> Handle(AcceptProposalCommand request, CancellationToken cancellationToken)
    {
        var acceptedProposal = await _proposalRepository.GetByIdAsync(request.Id);

        if (acceptedProposal == null)
            throw new NotFoundException("Proposal", request.Id);

        if (acceptedProposal.Status != ProposalStatus.Pending)
            throw new Exception("Only pending proposals can be accepted.");

        var jobPosting = await _jobPostingRepository.GetByIdAsync(acceptedProposal.JobPostingId);
        if (jobPosting == null)
            throw new NotFoundException("Job Posting", acceptedProposal.JobPostingId);

        // Accept the target proposal
        acceptedProposal.Status = ProposalStatus.Accepted;
        acceptedProposal.UpdatedDate = DateTime.UtcNow;
        await _proposalRepository.UpdateAsync(acceptedProposal);

        // Auto-reject all other proposals for the same JobPosting
        var otherProposals = await _proposalRepository.GetAllAsync(p => 
            p.JobPostingId == acceptedProposal.JobPostingId && 
            p.Id != acceptedProposal.Id &&
            p.Status == ProposalStatus.Pending);

        foreach (var proposal in otherProposals)
        {
            proposal.Status = ProposalStatus.Rejected;
            proposal.UpdatedDate = DateTime.UtcNow;
            await _proposalRepository.UpdateAsync(proposal);
        }

        // Create Contract
        var contract = new GigFlow.Domain.Entities.Contract
        {
            Id = Guid.NewGuid(),
            JobPostingId = acceptedProposal.JobPostingId,
            ProposalId = acceptedProposal.Id,
            FreelancerId = acceptedProposal.FreelancerId ?? Guid.Empty,
            ClientId = jobPosting.ClientId ?? Guid.Empty,
            TotalAmount = acceptedProposal.ProposedAmount,
            StartDate = DateTime.UtcNow,
            Status = ContractStatus.Active,
            CreatedDate = DateTime.UtcNow
        };
        await _contractRepository.AddAsync(contract);

        // Update JobPosting status to InProgress
        jobPosting.Status = JobStatus.InProgress;
        jobPosting.UpdatedDate = DateTime.UtcNow;
        await _jobPostingRepository.UpdateAsync(jobPosting);

        return true;
    }
}
