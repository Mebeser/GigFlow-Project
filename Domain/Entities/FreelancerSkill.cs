using System;

namespace GigFlow.Domain.Entities
{
    public class FreelancerSkill : BaseEntity
    {
        public Guid FreelancerProfileId { get; set; }
        public Guid SkillId { get; set; }

        // Navigation Properties
        public virtual FreelancerProfile FreelancerProfile { get; set; } = null!;
        public virtual Skill Skill { get; set; } = null!;
    }
}
