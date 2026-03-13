using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.Contracts.Commands.UpdateContractStatus;

public class UpdateContractStatusCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public ContractStatus Status { get; set; }
}
