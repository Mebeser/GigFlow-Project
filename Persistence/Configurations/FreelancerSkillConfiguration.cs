using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class FreelancerSkillConfiguration : IEntityTypeConfiguration<FreelancerSkill>
    {
        public void Configure(EntityTypeBuilder<FreelancerSkill> builder)
        {
            builder.HasKey(fs => new { fs.FreelancerProfileId, fs.SkillId });

            builder.HasOne(fs => fs.FreelancerProfile)
                .WithMany(fp => fp.FreelancerSkills)
                .HasForeignKey(fs => fs.FreelancerProfileId);

            builder.HasOne(fs => fs.Skill)
                .WithMany(s => s.FreelancerSkills)
                .HasForeignKey(fs => fs.SkillId);
        }
    }
}
