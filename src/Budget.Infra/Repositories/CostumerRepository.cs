using Budget.Core.Domain.Entities;
using Budget.Core.Interfaces.Repositories;

namespace Budget.Infra.Repositories;

public class CostumerRepository(BudgetDbContext context) : 
    BudgetGenericRepository<Costumer>(context), ICostumerRepository
{
}