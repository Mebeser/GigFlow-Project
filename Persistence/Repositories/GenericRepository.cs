using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using GigFlow.Persistence.Contexts;

namespace GigFlow.Persistence.Repositories;

public class GenericRepository<TEntity> : EfRepositoryBase<TEntity, GigFlowDbContext>, IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    public GenericRepository(GigFlowDbContext context) : base(context)
    {
    }
}
