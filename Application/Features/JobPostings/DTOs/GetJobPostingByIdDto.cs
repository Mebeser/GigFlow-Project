using GigFlow.Application.Features.Skills.DTOs;
using GigFlow.Domain.Enums;

namespace GigFlow.Application.Features.JobPostings.DTOs;

public class GetJobPostingByIdDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public decimal BudgetMin { get; set; }
    public decimal BudgetMax { get; set; }
    public BudgetType BudgetType { get; set; }
    public ProjectDuration Duration { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    public JobStatus Status { get; set; }
    public Guid? ClientId { get; set; }
    public DateTime? Deadline { get; set; }
    public DateTime CreatedDate { get; set; }

    public List<GetSkillListDto> Skills { get; set; } = new();
}
