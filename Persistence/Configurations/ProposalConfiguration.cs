using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CoverLetter).IsRequired().HasMaxLength(3000);
            builder.Property(p => p.ProposedAmount).HasColumnType("decimal(18,2)");
        }
    }
}
