using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.Contracts.Commands.UpdateContractStatus;

public class UpdateContractStatusCommandHandler : IRequestHandler<UpdateContractStatusCommand, bool>
{
    private readonly IContractRepository _contractRepository;

    public UpdateContractStatusCommandHandler(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<bool> Handle(UpdateContractStatusCommand request, CancellationToken cancellationToken)
    {
        var contract = await _contractRepository.GetByIdAsync(request.Id);

        if (contract == null)
            throw new NotFoundException("Contract", request.Id);

        if (contract.Status == ContractStatus.Cancelled)
            throw new Exception("Cannot update a cancelled contract.");

        contract.Status = request.Status;
        contract.UpdatedDate = DateTime.UtcNow;

        if (request.Status == ContractStatus.Completed || request.Status == ContractStatus.Cancelled)
        {
            contract.EndDate = DateTime.UtcNow;
        }

        await _contractRepository.UpdateAsync(contract);

        return true;
    }
}
