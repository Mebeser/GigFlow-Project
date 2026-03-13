using GigFlow.Domain.Enums;
using MediatR;

namespace GigFlow.Application.Features.JobPostings.Commands.CreateJobPosting;

public class CreateJobPostingCommand : IRequest<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public decimal BudgetMin { get; set; }
    public decimal BudgetMax { get; set; }
    public BudgetType BudgetType { get; set; }
    public ProjectDuration Duration { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    public Guid? ClientId { get; set; }
    public DateTime? Deadline { get; set; }
    
    // Skill ataması
    public List<Guid> SkillIds { get; set; } = new();
}
