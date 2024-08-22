using Budget.Core.Domain.Entities;
using Budget.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Budget.Infra.Repositories;

public class ProviderRepository(BudgetDbContext context) :
    BudgetGenericRepository<Provider>(context), IProviderRepository
{
    public Task<bool> ExistProvider(Provider provider)
    {
        return Table
            .AsNoTracking()
            .AnyAsync(p => provider.Name.Contains(p.Name) &&
                provider.Phone.Contains(p.Phone));
    }
}