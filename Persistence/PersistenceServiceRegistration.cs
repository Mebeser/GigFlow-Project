using GigFlow.Application.Repositories;
using GigFlow.Persistence.Contexts;
using GigFlow.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GigFlow.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GigFlowDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GigFlowConnectionString")));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IJobPostingRepository, JobPostingRepository>();
            services.AddScoped<IJobPostingSkillRepository, JobPostingSkillRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IMilestoneRepository, MilestoneRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();

            return services;
        }
    }
}
