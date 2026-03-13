using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class PortfolioRepository : EfRepositoryBase<Portfolio, GigFlowDbContext>, IPortfolioRepository
{
    public PortfolioRepository(GigFlowDbContext context) : base(context)
    {
    }
}
