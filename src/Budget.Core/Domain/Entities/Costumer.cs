using Budget.Core.Domain.Utils;

namespace Budget.Core.Domain.Entities;

public class Costumer : BaseEntity
{
    public string Name { get; private set; }
    public string Phone { get; private set; }

    protected Costumer(){}

    public static Costumer Create(
        string name,
        string phone
    ){
        return new Costumer
        {
            Name = name
                .ValidateString(Constants.MinNameLength, Constants.MaxNameLength),
            Phone = phone
                .ValidateString(Constants.MinDescriptionLength, Constants.MaxDescriptionLength)
        };
    }
}
