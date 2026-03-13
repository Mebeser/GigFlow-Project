using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class ContractRepository : EfRepositoryBase<Contract, GigFlowDbContext>, IContractRepository
{
    public ContractRepository(GigFlowDbContext context) : base(context)
    {
    }
}
