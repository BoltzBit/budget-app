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
        if(string.IsNullOrEmpty(name))
        {
            throw new Exception("Invalid name");
        }

        if(string.IsNullOrEmpty(phone))
        {
            throw new Exception("Invalid phone");
        }

        if(string.IsNullOrEmpty(description))
        {
            throw new Exception("Invalid Description");
        }

        if(serviceType <= 0)
        {
            throw new Exception("Invalid service type");
        }

        return new Provider
        {
            Name = name,
            Phone = phone,
            Description = description,
            ServiceType = serviceType
        };
    }
}
