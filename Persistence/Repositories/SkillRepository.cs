using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class SkillRepository : EfRepositoryBase<Skill, GigFlowDbContext>, ISkillRepository
{
    public SkillRepository(GigFlowDbContext context) : base(context)
    {
    }
}
