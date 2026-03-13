using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GigFlow.Persistence.Contexts
{
    public class GigFlowDbContext : DbContext
    {
        public GigFlowDbContext(DbContextOptions<GigFlowDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Skill> Skills { get; set; } = null!;
        public DbSet<JobPosting> JobPostings { get; set; } = null!;
        public DbSet<JobPostingSkill> JobPostingSkills { get; set; } = null!;
        public DbSet<Proposal> Proposals { get; set; } = null!;
        public DbSet<Contract> Contracts { get; set; } = null!;
        public DbSet<Milestone> Milestones { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Portfolio> Portfolios { get; set; } = null!;
        public DbSet<AppUser> AppUsers { get; set; } = null!;
        public DbSet<FreelancerProfile> FreelancerProfiles { get; set; } = null!;
        public DbSet<ClientProfile> ClientProfiles { get; set; } = null!;
        public DbSet<FreelancerSkill> FreelancerSkills { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GigFlowDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
