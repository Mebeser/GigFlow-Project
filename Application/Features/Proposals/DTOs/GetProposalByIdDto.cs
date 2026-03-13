using GigFlow.Domain.Enums;

namespace GigFlow.Application.Features.Proposals.DTOs;

public class GetProposalByIdDto
{
    public Guid Id { get; set; }
    public Guid JobPostingId { get; set; }
    public string JobPostingTitle { get; set; } = string.Empty;
    public Guid? FreelancerId { get; set; }
    public string CoverLetter { get; set; } = string.Empty;
    public decimal ProposedAmount { get; set; }
    public int EstimatedDuration { get; set; }
    public ProposalStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
}
