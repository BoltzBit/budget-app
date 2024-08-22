using Budget.Core.Domain;
using Budget.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Budget.Infra.Repositories;

public abstract class BudgetGenericRepository<T> :
    IBudgetGenericRepository<T> where T : BaseEntity
{
    private readonly BudgetDbContext _context;
    protected readonly DbSet<T> Table;

    public BudgetGenericRepository(BudgetDbContext context)
    {
        _context = context;
        Table = _context.Set<T>();
    }

    public virtual IQueryable<T> GetAll()
    {
        return _context
            .Set<T>()
            .AsQueryable();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context
            .Set<T>()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task InsertAsync(T entity)
    {
        await _context
            .Set<T>()
            .AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context
            .Set<T>()
            .Update(entity);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context
            .Set<T>()
            .Remove(entity);

        await _context.SaveChangesAsync();
    }
}
