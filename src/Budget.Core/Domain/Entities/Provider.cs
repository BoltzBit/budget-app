using Budget.Core.Domain.Utils;

namespace Budget.Core.Domain.Entities;

public class Provider : BaseEntity
{
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public string Description { get; private set; }

    public IReadOnlyCollection<Budget> Budgets { get; private set; }

    protected Provider(){}

    public void Update(Provider providerUpdate)
    {
        if(Name != providerUpdate.Name)
        {
            Name = providerUpdate
                .Name
                .ValidateString(Constants.MinNameLength, Constants.MaxNameLength);
        }

        if(Phone != providerUpdate.Phone)
        {
            Phone = providerUpdate
                .Phone
                .ValidateString(0, Constants.MaxPhoneLength);
        }

        if(Description != providerUpdate.Description)
        {
            Description = providerUpdate
                .Description
                .ValidateString(Constants.MinDescriptionLength, Constants.MaxDescriptionLength);
        }
    }

    public static Provider Create(
        string name,
        string phone,
        string description
    )
    {
        return new Provider
        {
            Name = name
                .ValidateString(Constants.MinNameLength, Constants.MaxNameLength),
            Phone = phone
                .ValidateString(5,9),
            Description = description
                .ValidateString(Constants.MinDescriptionLength, Constants.MaxDescriptionLength)
        };
    }
}
