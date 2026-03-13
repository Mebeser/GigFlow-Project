using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class AppUserRepository : EfRepositoryBase<AppUser, GigFlowDbContext>, IAppUserRepository
{
    public AppUserRepository(GigFlowDbContext context) : base(context)
    {
    }
}
