using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.TotalAmount).HasColumnType("decimal(18,2)");

            // Proposal -> Contract: 1 to 1 Example Context
            // The document says: Contract -> Milestone: 1 to M
            // Contract -> Review: 1 to M
            
            builder.HasMany(c => c.Milestones)
                .WithOne(m => m.Contract)
                .HasForeignKey(m => m.ContractId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.HasMany(c => c.Reviews)
                .WithOne(r => r.Contract)
                .HasForeignKey(r => r.ContractId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Freelancer)
                .WithMany()
                .HasForeignKey(c => c.FreelancerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Client)
                .WithMany()
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
