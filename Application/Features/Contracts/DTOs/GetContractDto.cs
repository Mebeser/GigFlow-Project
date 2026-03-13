using GigFlow.Domain.Enums;

namespace GigFlow.Application.Features.Contracts.DTOs;

public class GetContractDto
{
    public Guid Id { get; set; }
    public Guid JobPostingId { get; set; }
    public Guid ProposalId { get; set; }
    public Guid FreelancerId { get; set; }
    public Guid ClientId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ContractStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
}
