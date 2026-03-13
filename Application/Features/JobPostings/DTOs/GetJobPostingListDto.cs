using GigFlow.Domain.Enums;

namespace GigFlow.Application.Features.JobPostings.DTOs;

public class GetJobPostingListDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public decimal BudgetMin { get; set; }
    public decimal BudgetMax { get; set; }
    public BudgetType BudgetType { get; set; }
    public JobStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? Deadline { get; set; }
}
