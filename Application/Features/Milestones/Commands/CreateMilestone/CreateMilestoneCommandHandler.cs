using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.Milestones.Commands.CreateMilestone;

public class CreateMilestoneCommandHandler : IRequestHandler<CreateMilestoneCommand, Guid>
{
    private readonly IMilestoneRepository _milestoneRepository;
    private readonly IContractRepository _contractRepository;

    public CreateMilestoneCommandHandler(
        IMilestoneRepository milestoneRepository,
        IContractRepository contractRepository)
    {
        _milestoneRepository = milestoneRepository;
        _contractRepository = contractRepository;
    }

    public async Task<Guid> Handle(CreateMilestoneCommand request, CancellationToken cancellationToken)
    {
        var contract = await _contractRepository.GetByIdAsync(request.ContractId);
        if (contract == null)
            throw new Exception("Contract not found.");

        if (contract.Status != ContractStatus.Active)
            throw new Exception("Milestones can only be added to active contracts.");

        // Ensure total amount does not exceed contract amount
        var existingMilestones = await _milestoneRepository.GetAllAsync(m => m.ContractId == request.ContractId);
        var currentTotal = existingMilestones.Sum(m => m.Amount);
        if (currentTotal + request.Amount > contract.TotalAmount)
            throw new Exception($"Total milestone amount ({currentTotal + request.Amount}) would exceed contract amount ({contract.TotalAmount}).");

        var milestone = new Milestone
        {
            Id = Guid.NewGuid(),
            ContractId = request.ContractId,
            Title = request.Title,
            Description = request.Description,
            Amount = request.Amount,
            DueDate = request.DueDate,
            Status = MilestoneStatus.Pending,
            CreatedDate = DateTime.UtcNow
        };

        await _milestoneRepository.AddAsync(milestone);
        return milestone.Id;
    }
}
