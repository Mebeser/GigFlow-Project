using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.Proposals.Commands.WithdrawProposal;

public class WithdrawProposalCommandHandler : IRequestHandler<WithdrawProposalCommand, bool>
{
    private readonly IProposalRepository _proposalRepository;

    public WithdrawProposalCommandHandler(IProposalRepository proposalRepository)
    {
        _proposalRepository = proposalRepository;
    }

    public async Task<bool> Handle(WithdrawProposalCommand request, CancellationToken cancellationToken)
    {
        var proposal = await _proposalRepository.GetByIdAsync(request.Id);

        if (proposal == null)
            throw new NotFoundException("Proposal", request.Id);

        if (proposal.Status == ProposalStatus.Withdrawn)
            throw new Exception("Proposal is already withdrawn.");
            
        if (proposal.Status == ProposalStatus.Accepted)
            throw new Exception("Cannot withdraw an accepted proposal.");

        proposal.Status = ProposalStatus.Withdrawn;
        proposal.UpdatedDate = DateTime.UtcNow;

        await _proposalRepository.UpdateAsync(proposal);
        return true;
    }
}
