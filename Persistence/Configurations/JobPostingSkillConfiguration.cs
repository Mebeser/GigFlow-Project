using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class JobPostingSkillConfiguration : IEntityTypeConfiguration<JobPostingSkill>
    {
        public void Configure(EntityTypeBuilder<JobPostingSkill> builder)
        {
            builder.HasKey(jps => new { jps.JobPostingId, jps.SkillId });
            
            // Ignore BaseEntity Id for this join table because we use composite PK
            // We'll leave the inherited Id available but not as PK.
            // Or we could ignore it completely from the database:
            // builder.Ignore(jps => jps.Id); 
            // However since it inherits from BaseEntity, keeping it but not using it as PK is one option
            // Let's just make sure the composite key is the PK:
            
            builder.HasOne(jps => jps.JobPosting)
                .WithMany(jp => jp.JobPostingSkills)
                .HasForeignKey(jps => jps.JobPostingId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.HasOne(jps => jps.Skill)
                .WithMany(s => s.JobPostingSkills)
                .HasForeignKey(jps => jps.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(
                // Job 1 (Web Dev) requires React, .NET Core, SQL
                new JobPostingSkill { JobPostingId = Guid.Parse("B1111111-1111-1111-1111-111111111111"), SkillId = Guid.Parse("A1111111-1111-1111-1111-111111111111") },
                new JobPostingSkill { JobPostingId = Guid.Parse("B1111111-1111-1111-1111-111111111111"), SkillId = Guid.Parse("A1111111-1111-1111-1111-111111111112") },
                new JobPostingSkill { JobPostingId = Guid.Parse("B1111111-1111-1111-1111-111111111111"), SkillId = Guid.Parse("A5555555-5555-5555-5555-555555555553") },

                // Job 2 (Mobile App UI/UX) requires Figma, Illustrator
                new JobPostingSkill { JobPostingId = Guid.Parse("B2222222-2222-2222-2222-222222222222"), SkillId = Guid.Parse("A3333333-3333-3333-3333-333333333331") },
                new JobPostingSkill { JobPostingId = Guid.Parse("B2222222-2222-2222-2222-222222222222"), SkillId = Guid.Parse("A3333333-3333-3333-3333-333333333332") },

                // Job 3 (Flutter MVP) requires Flutter
                new JobPostingSkill { JobPostingId = Guid.Parse("B3333333-3333-3333-3333-333333333333"), SkillId = Guid.Parse("A2222222-2222-2222-2222-222222222221") }
            );
        }
    }
}
