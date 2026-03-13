using System;
using System.Collections.Generic;

namespace GigFlow.Domain.Entities
{
    public class FreelancerProfile : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }
        public decimal AverageRating { get; set; }
        public decimal TotalEarnings { get; set; }

        // Navigation Properties
        public virtual AppUser User { get; set; } = null!;
        public virtual ICollection<FreelancerSkill> FreelancerSkills { get; set; } = new List<FreelancerSkill>();
        public virtual ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
