using MediatR;

namespace GigFlow.Application.Features.Proposals.Commands.WithdrawProposal;

public class WithdrawProposalCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
