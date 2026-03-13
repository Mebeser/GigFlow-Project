using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class JobPostingSkillRepository : EfRepositoryBase<JobPostingSkill, GigFlowDbContext>, IJobPostingSkillRepository
{
    public JobPostingSkillRepository(GigFlowDbContext context) : base(context)
    {
    }
}
