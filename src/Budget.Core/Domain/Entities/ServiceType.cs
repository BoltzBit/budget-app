using Budget.Core.Domain.Utils;

namespace Budget.Core.Domain.Entities;

public class ServiceType : BaseEntity
{
    public int ProviderId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public IReadOnlyCollection<Provider> Providers { get; private set; }

    protected ServiceType(){}

    public void Update(ServiceType serviceType)
    {
        if(serviceType.ProviderId != ProviderId)
        {
            ProviderId = serviceType.ProviderId;
        }

        if(serviceType.Name != Name)
        {
            Name = serviceType
                .Name
                .ValidateString(2, 100);
        }

        if(serviceType.Description != Description)
        {
            Description = serviceType
                .Description
                .ValidateString(2, 2000);
        }
    }

    public ServiceType Create(
        int providerId,
        string name,
        string description
    )
    {
        return new ServiceType
        {
            ProviderId = providerId.ValidateInt(),
            Name = name.ValidateString(2, 100),
            Description = description.ValidateString(2, 2000)
        };
    }
}
