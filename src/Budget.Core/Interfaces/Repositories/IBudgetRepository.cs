using BudgetEntity = Budget.Core.Domain.Entities.Budget;

namespace Budget.Core.Interfaces.Repositories;

public interface IBudgetRepository : IBudgetGenericRepository<BudgetEntity>
{
    
}
