using MediatR;

namespace GigFlow.Application.Features.Proposals.Commands.AcceptProposal;

public class AcceptProposalCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
