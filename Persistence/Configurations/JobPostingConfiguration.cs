using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class JobPostingConfiguration : IEntityTypeConfiguration<JobPosting>
    {
        public void Configure(EntityTypeBuilder<JobPosting> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Title).IsRequired().HasMaxLength(200);
            builder.Property(j => j.Description).IsRequired().HasMaxLength(5000);
            
            builder.Property(j => j.BudgetMin).HasColumnType("decimal(18,2)");
            builder.Property(j => j.BudgetMax).HasColumnType("decimal(18,2)");
            
            builder.HasMany(j => j.Proposals)
                .WithOne(p => p.JobPosting)
                .HasForeignKey(p => p.JobPostingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data
            builder.HasData(
                new JobPosting 
                { 
                    Id = Guid.Parse("B1111111-1111-1111-1111-111111111111"), 
                    Title = "Full Stack .NET Developer Needed for E-Commerce App", 
                    Description = "We are looking for an experienced .NET Core and React developer to build our next gen e-commerce platform.", 
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                    BudgetMin = 2000, 
                    BudgetMax = 5000, 
                    BudgetType = GigFlow.Domain.Enums.BudgetType.Fixed, 
                    Duration = GigFlow.Domain.Enums.ProjectDuration.Long, 
                    ExperienceLevel = GigFlow.Domain.Enums.ExperienceLevel.Expert, 
                    Status = GigFlow.Domain.Enums.JobStatus.Open, 
                    CreatedDate = new DateTime(2026, 3, 11)
                },
                new JobPosting 
                { 
                    Id = Guid.Parse("B2222222-2222-2222-2222-222222222222"), 
                    Title = "UI/UX Designer for Mobile App Redesign", 
                    Description = "Looking for a talented Figma designer to redesign our existing fitness tracking mobile application.", 
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"), 
                    BudgetMin = 30, 
                    BudgetMax = 50, 
                    BudgetType = GigFlow.Domain.Enums.BudgetType.Hourly, 
                    Duration = GigFlow.Domain.Enums.ProjectDuration.Medium, 
                    ExperienceLevel = GigFlow.Domain.Enums.ExperienceLevel.Intermediate, 
                    Status = GigFlow.Domain.Enums.JobStatus.Open, 
                    CreatedDate = new DateTime(2026, 3, 11)
                },
                new JobPosting 
                { 
                    Id = Guid.Parse("B3333333-3333-3333-3333-333333333333"), 
                    Title = "Flutter Developer required for MVP", 
                    Description = "We need an MVP for an ad-hoc local delivery app built and shipped in 6 weeks using Flutter.", 
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"), 
                    BudgetMin = 1500, 
                    BudgetMax = 3000, 
                    BudgetType = GigFlow.Domain.Enums.BudgetType.Fixed, 
                    Duration = GigFlow.Domain.Enums.ProjectDuration.Short, 
                    ExperienceLevel = GigFlow.Domain.Enums.ExperienceLevel.Intermediate, 
                    Status = GigFlow.Domain.Enums.JobStatus.Open, 
                    CreatedDate = new DateTime(2026, 3, 11)
                }
            );
        }
    }
}
