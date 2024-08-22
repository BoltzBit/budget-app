using Budget.Core.Domain.Entities;

namespace Budget.Core.Interfaces.Repositories;

public interface IProviderRepository : IBudgetGenericRepository<Provider>
{
    Task<bool> ExistProvider(Provider provider);
}