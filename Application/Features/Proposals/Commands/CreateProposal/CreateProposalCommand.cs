using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.Proposals.Commands.CreateProposal;

public class CreateProposalCommand : IRequest<Guid>
{
    public Guid JobPostingId { get; set; }
    public Guid? FreelancerId { get; set; }
    public string CoverLetter { get; set; } = string.Empty;
    public decimal ProposedAmount { get; set; }
    public int EstimatedDuration { get; set; }
}
