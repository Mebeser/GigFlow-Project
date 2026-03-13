using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.RefreshToken).HasMaxLength(500);
            builder.Property(u => u.RefreshTokenExpiryTime);

            builder.HasOne(u => u.FreelancerProfile)
                .WithOne(fp => fp.User)
                .HasForeignKey<FreelancerProfile>(fp => fp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.ClientProfile)
                .WithOne(cp => cp.User)
                .HasForeignKey<ClientProfile>(cp => cp.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
