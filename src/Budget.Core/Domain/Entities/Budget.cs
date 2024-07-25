using Budget.Core.Domain.Utils;

namespace Budget.Core.Domain.Entities;

public class Budget : BaseEntity
{
    public Guid CostumerId { get; private set; }
    public Guid ProviderId { get; private set; }
    public double Total { get; private set; }
    public DateTime Deadline { get; private set; }
    public int Type { get; private set; }
    public bool IsAccepted { get; private set; }

    public Costumer Costumer { get; private set; }
    public Provider Provider { get; private set; }

    protected Budget() { }

    public static Budget Create(
        Guid costumerId,
        Guid providerId,
        DateTime deadline,
        int type
    )
    {
        return new Budget
        {
            CostumerId = costumerId.ValidateGuid(),
            ProviderId = providerId.ValidateGuid(),
            Deadline = deadline,
            Type = type.ValidateInt()
        };
    }
}