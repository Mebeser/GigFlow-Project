using System.Linq.Expressions;
using GigFlow.Domain.Entities;

namespace GigFlow.Application.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
