using Budget.Core.Domain.Utils;

namespace Budget.Core.Domain.Entities;

public class ServiceType : BaseEntity
{
    public Guid ProviderId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Provider Provider { get; private set; }

    protected ServiceType(){}

    public void Update(ServiceType serviceType)
    {
        if(serviceType.ProviderId != ProviderId)
        {
            ProviderId = serviceType
                .ProviderId
                .ValidateGuid();
        }

        if(serviceType.Name != Name)
        {
            Name = serviceType
                .Name
                .ValidateString(
                    Constants.MinNameLength, 
                    Constants.MaxNameLength);
        }

        if(serviceType.Description != Description)
        {
            Description = serviceType
                .Description
                .ValidateString(
                    Constants.MinDescriptionLength,
                    Constants.MaxDescriptionLength);
        }
    }

    public ServiceType Create(
        Guid providerId,
        string name,
        string description
    )
    {
        return new ServiceType
        {
            ProviderId = providerId
                .ValidateGuid(),
            Name = name.ValidateString(
                Constants.MinNameLength, 
                Constants.MaxNameLength),
            Description = description.ValidateString(
                Constants.MinDescriptionLength,
                Constants.MaxDescriptionLength)
        };
    }
}
