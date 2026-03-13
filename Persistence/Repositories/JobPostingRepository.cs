using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class JobPostingRepository : EfRepositoryBase<JobPosting, GigFlowDbContext>, IJobPostingRepository
{
    public JobPostingRepository(GigFlowDbContext context) : base(context)
    {
    }
}
