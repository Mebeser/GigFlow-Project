using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.Milestones.Commands.UpdateMilestoneStatus;

public class UpdateMilestoneStatusCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public MilestoneStatus Status { get; set; }
}
