using GigFlow.Application.Repositories;
using GigFlow.Domain.Enums;
using MediatR;
using GigFlow.Application.Exceptions;

namespace GigFlow.Application.Features.Milestones.Commands.UpdateMilestoneStatus;

public class UpdateMilestoneStatusCommandHandler : IRequestHandler<UpdateMilestoneStatusCommand, bool>
{
    private readonly IMilestoneRepository _milestoneRepository;
    private readonly IContractRepository _contractRepository;

    public UpdateMilestoneStatusCommandHandler(
        IMilestoneRepository milestoneRepository,
        IContractRepository contractRepository)
    {
        _milestoneRepository = milestoneRepository;
        _contractRepository = contractRepository;
    }

    public async Task<bool> Handle(UpdateMilestoneStatusCommand request, CancellationToken cancellationToken)
    {
        var milestone = await _milestoneRepository.GetByIdAsync(request.Id);

        if (milestone == null)
            throw new NotFoundException("Milestone", request.Id);

        milestone.Status = request.Status;
        milestone.UpdatedDate = DateTime.UtcNow;
        await _milestoneRepository.UpdateAsync(milestone);

        // Kritik kural: Tüm milestone'lar Approved olduğunda sözleşmeyi Completed yap
        if (request.Status == MilestoneStatus.Approved)
        {
            var allMilestones = await _milestoneRepository.GetAllAsync(m => m.ContractId == milestone.ContractId);

            bool allApproved = allMilestones.Any() && allMilestones.All(m => m.Status == MilestoneStatus.Approved);

            if (allApproved)
            {
                var contract = await _contractRepository.GetByIdAsync(milestone.ContractId);
                if (contract != null && contract.Status == ContractStatus.Active)
                {
                    contract.Status = ContractStatus.Completed;
                    contract.EndDate = DateTime.UtcNow;
                    contract.UpdatedDate = DateTime.UtcNow;
                    await _contractRepository.UpdateAsync(contract);
                }
            }
        }

        return true;
    }
}
