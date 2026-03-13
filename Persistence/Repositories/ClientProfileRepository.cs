using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class ClientProfileRepository : EfRepositoryBase<ClientProfile, GigFlowDbContext>, IClientProfileRepository
{
    public ClientProfileRepository(GigFlowDbContext context) : base(context)
    {
    }
}
