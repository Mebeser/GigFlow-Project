using MediatR;

namespace GigFlow.Application.Features.Proposals.Commands.RejectProposal;

public class RejectProposalCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
