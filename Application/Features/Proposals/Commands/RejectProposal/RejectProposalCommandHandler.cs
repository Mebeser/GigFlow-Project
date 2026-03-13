using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.Proposals.Commands.RejectProposal;

public class RejectProposalCommandHandler : IRequestHandler<RejectProposalCommand, bool>
{
    private readonly IProposalRepository _proposalRepository;

    public RejectProposalCommandHandler(IProposalRepository proposalRepository)
    {
        _proposalRepository = proposalRepository;
    }

    public async Task<bool> Handle(RejectProposalCommand request, CancellationToken cancellationToken)
    {
        var proposal = await _proposalRepository.GetByIdAsync(request.Id);

        if (proposal == null)
            throw new NotFoundException("Proposal", request.Id);

        if (proposal.Status != ProposalStatus.Pending)
            throw new Exception("Only pending proposals can be rejected.");

        proposal.Status = ProposalStatus.Rejected;
        proposal.UpdatedDate = DateTime.UtcNow;

        await _proposalRepository.UpdateAsync(proposal);
        return true;
    }
}
