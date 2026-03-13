using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class FreelancerProfileRepository : EfRepositoryBase<FreelancerProfile, GigFlowDbContext>, IFreelancerProfileRepository
{
    public FreelancerProfileRepository(GigFlowDbContext context) : base(context)
    {
    }
}
