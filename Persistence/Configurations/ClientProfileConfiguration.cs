using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class ClientProfileConfiguration : IEntityTypeConfiguration<ClientProfile>
    {
        public void Configure(EntityTypeBuilder<ClientProfile> builder)
        {
            builder.HasKey(cp => cp.Id);
            builder.Property(cp => cp.CompanyName).HasMaxLength(200);
            builder.Property(cp => cp.Website).HasMaxLength(500);
            builder.Property(cp => cp.TotalSpent).HasColumnType("decimal(18,2)");

            builder.HasMany(cp => cp.JobPostings)
                .WithOne(jp => jp.Client)
                .HasForeignKey(jp => jp.ClientId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
