using System;
using System.Collections.Generic;

namespace GigFlow.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        
        public ICollection<JobPostingSkill> JobPostingSkills { get; set; } = new List<JobPostingSkill>();
        public virtual ICollection<FreelancerSkill> FreelancerSkills { get; set; } = new List<FreelancerSkill>();
    }
}
