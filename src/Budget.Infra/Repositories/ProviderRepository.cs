using Budget.Core.Domain.Entities;
using Budget.Core.Interfaces.Repositories;

namespace Budget.Infra.Repositories;

public class ProviderRepository(BudgetDbContext context) : 
    BudgetGenericRepository<Provider>(context), IProviderRepository
{
}