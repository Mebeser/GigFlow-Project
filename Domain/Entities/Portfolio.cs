using System;

namespace GigFlow.Domain.Entities
{
    public class Portfolio : BaseEntity
    {
        public Guid FreelancerId { get; set; }
        public virtual FreelancerProfile FreelancerProfile { get; set; } = null!;
        
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public string? ProjectUrl { get; set; }
        public string? ImageUrl { get; set; }
    }
}
