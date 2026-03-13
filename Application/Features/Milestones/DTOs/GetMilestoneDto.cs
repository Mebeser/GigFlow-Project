using GigFlow.Domain.Enums;

namespace GigFlow.Application.Features.Milestones.DTOs;

public class GetMilestoneDto
{
    public Guid Id { get; set; }
    public Guid ContractId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public MilestoneStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
}
