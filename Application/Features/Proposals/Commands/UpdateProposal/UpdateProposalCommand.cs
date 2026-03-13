using MediatR;

namespace GigFlow.Application.Features.Proposals.Commands.UpdateProposal;

public class UpdateProposalCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string CoverLetter { get; set; } = string.Empty;
    public decimal ProposedAmount { get; set; }
    public int EstimatedDuration { get; set; }
}
