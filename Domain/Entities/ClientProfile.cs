using System;
using System.Collections.Generic;

namespace GigFlow.Domain.Entities
{
    public class ClientProfile : BaseEntity
    {
        public Guid UserId { get; set; }
        public string? CompanyName { get; set; }
        public string? Website { get; set; }
        public decimal TotalSpent { get; set; }

        // Navigation Properties
        public virtual AppUser User { get; set; } = null!;
        public virtual ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
    }
}
