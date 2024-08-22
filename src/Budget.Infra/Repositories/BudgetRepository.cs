using BudgetEntity = Budget.Core.Domain.Entities.Budget;
using Budget.Core.Interfaces.Repositories;

namespace Budget.Infra.Repositories;

public class BudgetRepository(BudgetDbContext context) : 
    BudgetGenericRepository<BudgetEntity>(context), IBudgetRepository
{
}