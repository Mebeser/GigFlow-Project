using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class FreelancerProfileConfiguration : IEntityTypeConfiguration<FreelancerProfile>
    {
        public void Configure(EntityTypeBuilder<FreelancerProfile> builder)
        {
            builder.HasKey(fp => fp.Id);
            builder.Property(fp => fp.Title).HasMaxLength(200);
            builder.Property(fp => fp.Bio).HasMaxLength(3000);
            builder.Property(fp => fp.HourlyRate).HasColumnType("decimal(18,2)");
            builder.Property(fp => fp.AverageRating).HasColumnType("decimal(3,2)");
            builder.Property(fp => fp.TotalEarnings).HasColumnType("decimal(18,2)");

            builder.HasMany(fp => fp.FreelancerSkills)
                .WithOne(fs => fs.FreelancerProfile)
                .HasForeignKey(fs => fs.FreelancerProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(fp => fp.Portfolios)
                .WithOne(p => p.FreelancerProfile)
                .HasForeignKey(p => p.FreelancerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
