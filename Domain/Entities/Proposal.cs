using System;
using GigFlow.Domain.Enums;

namespace GigFlow.Domain.Entities
{
    public class Proposal : BaseEntity
    {
        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = null!;
        
        public Guid? FreelancerId { get; set; }
        public virtual FreelancerProfile? Freelancer { get; set; }
        
        public string CoverLetter { get; set; } = string.Empty;
        public decimal ProposedAmount { get; set; }
        public int EstimatedDuration { get; set; }
        
        public ProposalStatus Status { get; set; }
    }
}
