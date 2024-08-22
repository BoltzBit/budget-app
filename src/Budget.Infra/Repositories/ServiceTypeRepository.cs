using Budget.Core.Domain.Entities;
using Budget.Core.Interfaces.Repositories;

namespace Budget.Infra.Repositories;

public class ServiceTypeRepository(BudgetDbContext context) : 
    BudgetGenericRepository<ServiceType>(context), IServiceTypeRepository
{
}