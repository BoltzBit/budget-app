using Budget.Core.Domain.Utils;

namespace Budget.Core.Domain.Entities;

public class Provider : BaseEntity
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public int ServiceType { get; set; }
    public string Description { get; set; }

    protected Provider(){}

    public static Provider Create(
        string name,
        string phone,
        string description,
        int serviceType
    )
    {
        if(serviceType <= 0)
        {
            throw new Exception("Invalid service type");
        }

        return new Provider
        {
            Name = name
                .ValidateString(Constants.MinNameLength, Constants.MaxNameLength),
            Phone = phone
                .ValidateString(5,9),
            Description = description
                .ValidateString(Constants.MinDescriptionLength, Constants.MaxDescriptionLength),
            ServiceType = serviceType.ValidateInt()
        };
    }
}
