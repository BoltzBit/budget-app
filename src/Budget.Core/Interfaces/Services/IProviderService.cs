using Budget.Core.Domain.Entities;

namespace Budget.Core.Interfaces.Services;

public interface IProviderService
{
    Task<Guid> InsertAsync(Provider provider);
}