using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class MilestoneRepository : EfRepositoryBase<Milestone, GigFlowDbContext>, IMilestoneRepository
{
    public MilestoneRepository(GigFlowDbContext context) : base(context)
    {
    }
}
