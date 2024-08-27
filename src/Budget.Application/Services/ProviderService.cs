using Budget.Core.Domain.Entities;
using Budget.Core.Interfaces.Services;
using Budget.Core.Interfaces.Repositories;

namespace Budget.Application.Services;

public class ProviderService : IProviderService
{
    private readonly IProviderRepository _providerRepository;

    public ProviderService(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async Task<Guid> InsertAsync(Provider provider)
    {
        var existProvider = await _providerRepository.ExistProvider(provider);

        if(existProvider)
        {
            throw new ApplicationException($"Exist provider with the name: {provider.Name}; phone: {provider.Phone}");
        }

        return await _providerRepository.InsertAsync(provider);
    }
}

