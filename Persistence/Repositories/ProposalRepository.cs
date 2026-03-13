using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class ProposalRepository : EfRepositoryBase<Proposal, GigFlowDbContext>, IProposalRepository
{
    public ProposalRepository(GigFlowDbContext context) : base(context)
    {
    }
}
