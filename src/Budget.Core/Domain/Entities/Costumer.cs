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
        if(string.IsNullOrEmpty(name))
        {
            throw new Exception("Invalid name");
        }

        if(string.IsNullOrEmpty(phone))
        {
            throw new Exception("Invalid phone");
        }

        return new Costumer
        {
            Name = name,
            Phone = phone
        };
    }
}
