using Budget.Core.Domain.Utils;

namespace Budget.Core.Domain.Entities;

public class Costumer : BaseEntity
{
    private const int MinNameLength = 2;
    private const int MaxNameLength = 250;
    private const int MinDescriptionLength = 2;
    private const int MaxDescriptionLength = 250;
    
    public string Name { get; private set; }
    public string Phone { get; private set; }

    protected Costumer(){}

    public static Costumer Create(
        string name,
        string phone
    ){
        return new Costumer
        {
            Name = name.ValidateString(MinNameLength, MaxNameLength),
            Phone = phone.ValidateString(MinDescriptionLength, MaxDescriptionLength)
        };
    }
}
