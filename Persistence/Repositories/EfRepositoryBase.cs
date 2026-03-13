using System.Linq.Expressions;
using GigFlow.Application.Repositories;
using GigFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GigFlow.Persistence.Repositories;

public class EfRepositoryBase<TEntity, TContext> : IGenericRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        if (predicate != null)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        return await Context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        await Context.SaveChangesAsync();
        return entity;
    }
}
