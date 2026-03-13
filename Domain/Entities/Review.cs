using System;

namespace GigFlow.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; } = null!;
        
        public Guid ReviewerId { get; set; }
        public Guid RevieweeId { get; set; }
        
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
