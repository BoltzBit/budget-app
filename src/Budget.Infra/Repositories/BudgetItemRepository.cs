using Budget.Core.Domain.Entities;
using Budget.Core.Interfaces.Repositories;

namespace Budget.Infra.Repositories;

public class BudgetItemRepository(BudgetDbContext context) : 
    BudgetGenericRepository<BudgetItem>(context), IBudgetItemRepository
{
}
