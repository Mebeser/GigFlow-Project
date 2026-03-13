using System;
using System.Collections.Generic;

namespace GigFlow.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        
        public Guid? ParentCategoryId { get; set; }
        
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
    }
}
