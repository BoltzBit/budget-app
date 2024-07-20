using Budget.Core.Domain.Utils;

namespace Budget.Core.Domain.Entities;

public class Costumer : BaseEntity
{
    public string Name { get; private set; }
    public string Phone { get; private set; }

    protected Costumer(){}

    public void Update(Costumer costumerUpdate)
    {
        if(Name != costumerUpdate.Name)
        {
            Name = costumerUpdate
                .Name
                .ValidateString(Constants.MinNameLength, Constants.MaxNameLength);
        }

        if(Phone != costumerUpdate.Phone)
        {
            Phone = costumerUpdate
                .Phone
                .ValidateString(0, Constants.MaxPhoneLength);
        }
    }
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
