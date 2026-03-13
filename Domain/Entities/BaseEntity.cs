using System;

namespace GigFlow.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
