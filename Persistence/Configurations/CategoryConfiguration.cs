using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(500);

            

            builder.HasMany(c => c.Skills)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.HasMany(c => c.JobPostings)
                .WithOne(j => j.Category)
                .HasForeignKey(j => j.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(
                new Category { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Yazılım Geliştirme", Description = "Ön yüz ve arka yüz web geliştirme hizmetleri", CreatedDate = new DateTime(2026, 3, 11) },
                new Category { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Mobil Uygulama", Description = "iOS ve Android uygulama geliştirme", CreatedDate = new DateTime(2026, 3, 11) },
                new Category { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Grafik Tasarım", Description = "Logo, UI/UX ve illüstrasyon tasarımı", CreatedDate = new DateTime(2026, 3, 11) },
                new Category { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Dijital Pazarlama", Description = "SEO, SEM ve Sosyal Medya Yönetimi", CreatedDate = new DateTime(2026, 3, 11) },
                new Category { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Veri Bilimi", Description = "Veri analizi, Makine Öğrenmesi ve Yapay Zeka", CreatedDate = new DateTime(2026, 3, 11) }
            );
        }
    }
}
