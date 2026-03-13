using System;
using System.Collections.Generic;
using GigFlow.Domain.Enums;

namespace GigFlow.Domain.Entities
{
    public class JobPosting : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        
        public decimal BudgetMin { get; set; }
        public decimal BudgetMax { get; set; }
        
        public BudgetType BudgetType { get; set; }
        public ProjectDuration Duration { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public JobStatus Status { get; set; }
        
        public Guid? ClientId { get; set; }
        public DateTime? Deadline { get; set; }
        
        public ICollection<JobPostingSkill> JobPostingSkills { get; set; } = new List<JobPostingSkill>();
        public ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
    }
}
