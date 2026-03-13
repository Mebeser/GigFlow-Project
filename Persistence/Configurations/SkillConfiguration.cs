using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GigFlow.Persistence.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);

            // The relationship with Category is already configured from Category side,
            // but we can reiterate or leave it. We leave it configured via Category side
            // or here, doing it here too is fine.

            // Seed Data
            builder.HasData(
                // Yazılım Geliştirme Yetenekleri
                new Skill { Id = Guid.Parse("A1111111-1111-1111-1111-111111111111"), Name = "React", CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"), CreatedDate = new DateTime(2026, 3, 11) },
                new Skill { Id = Guid.Parse("A1111111-1111-1111-1111-111111111112"), Name = ".NET Core", CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"), CreatedDate = new DateTime(2026, 3, 11) },
                new Skill { Id = Guid.Parse("A1111111-1111-1111-1111-111111111113"), Name = "Node.js", CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"), CreatedDate = new DateTime(2026, 3, 11) },
                
                // Mobil Uygulama Yetenekleri
                new Skill { Id = Guid.Parse("A2222222-2222-2222-2222-222222222221"), Name = "Flutter", CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"), CreatedDate = new DateTime(2026, 3, 11) },
                new Skill { Id = Guid.Parse("A2222222-2222-2222-2222-222222222222"), Name = "Swift", CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"), CreatedDate = new DateTime(2026, 3, 11) },
                new Skill { Id = Guid.Parse("A2222222-2222-2222-2222-222222222223"), Name = "Kotlin", CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"), CreatedDate = new DateTime(2026, 3, 11) },

                // Grafik Tasarım Yetenekleri
                new Skill { Id = Guid.Parse("A3333333-3333-3333-3333-333333333331"), Name = "Figma", CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"), CreatedDate = new DateTime(2026, 3, 11) },
                new Skill { Id = Guid.Parse("A3333333-3333-3333-3333-333333333332"), Name = "Adobe Illustrator", CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"), CreatedDate = new DateTime(2026, 3, 11) },
                new Skill { Id = Guid.Parse("A3333333-3333-3333-3333-333333333333"), Name = "Adobe Photoshop", CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"), CreatedDate = new DateTime(2026, 3, 11) },

                // Dijital Pazarlama Yetenekleri
                new Skill { Id = Guid.Parse("A4444444-4444-4444-4444-444444444441"), Name = "SEO", CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"), CreatedDate = new DateTime(2026, 3, 11)},
                new Skill { Id = Guid.Parse("A4444444-4444-4444-4444-444444444442"), Name = "Google Ads", CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"), CreatedDate = new DateTime(2026, 3, 11) },
                new Skill { Id = Guid.Parse("A4444444-4444-4444-4444-444444444443"), Name = "Sosyal Medya Yönetimi", CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"), CreatedDate = new DateTime(2026, 3, 11) },

                // Veri Bilimi Yetenekleri
                new Skill { Id = Guid.Parse("A5555555-5555-5555-5555-555555555551"), Name = "Python", CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"), CreatedDate = new DateTime(2026, 3, 11) },
                new Skill { Id = Guid.Parse("A5555555-5555-5555-5555-555555555552"), Name = "Makine Öğrenmesi", CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"),CreatedDate = new DateTime(2026, 3, 11) },
                new Skill { Id = Guid.Parse("A5555555-5555-5555-5555-555555555553"), Name = "SQL", CategoryId = Guid.Parse("55555555-5555-5555-5555-555555555555"), CreatedDate = new DateTime(2026, 3, 11) }
            );
        }
    }
}
