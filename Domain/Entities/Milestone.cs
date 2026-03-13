using System;
using GigFlow.Domain.Enums;

namespace GigFlow.Domain.Entities
{
    public class Milestone : BaseEntity
    {
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; } = null!;
        
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        
        public MilestoneStatus Status { get; set; }
    }
}
