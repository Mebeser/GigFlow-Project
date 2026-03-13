using System;

namespace GigFlow.Domain.Entities
{
    public class JobPostingSkill : BaseEntity
    {
        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = null!;
        
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; } = null!;
    }
}
