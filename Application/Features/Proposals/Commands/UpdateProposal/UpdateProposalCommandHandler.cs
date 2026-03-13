using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.Proposals.Commands.UpdateProposal;

public class UpdateProposalCommandHandler : IRequestHandler<UpdateProposalCommand, bool>
{
    private readonly IProposalRepository _proposalRepository;

    public UpdateProposalCommandHandler(IProposalRepository proposalRepository)
    {
        _proposalRepository = proposalRepository;
    }

    public async Task<bool> Handle(UpdateProposalCommand request, CancellationToken cancellationToken)
    {
        var proposal = await _proposalRepository.GetByIdAsync(request.Id);

        if (proposal == null)
            throw new NotFoundException("Proposal", request.Id);

        if (proposal.Status != ProposalStatus.Pending)
            throw new Exception("Only pending proposals can be updated.");

        proposal.CoverLetter = request.CoverLetter;
        proposal.ProposedAmount = request.ProposedAmount;
        proposal.EstimatedDuration = request.EstimatedDuration;
        proposal.UpdatedDate = DateTime.UtcNow;

        await _proposalRepository.UpdateAsync(proposal);
        return true;
    }
}
