using Budget.Core.Domain;

namespace Budget.Core.Interfaces.Repositories;

public interface IBudgetGenericRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(Guid id);
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}