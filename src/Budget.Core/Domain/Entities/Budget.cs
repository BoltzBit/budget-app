using Budget.Core.Domain.Enuns;
using Budget.Core.Domain.Utils;

namespace Budget.Core.Domain.Entities;

public class Budget : BaseEntity
{
    public Guid CostumerId { get; private set; }
    public Guid ProviderId { get; private set; }
    public decimal Total { get; private set; }
    public DateTime Deadline { get; private set; }
    public BudgetType Type { get; private set; }
    public bool IsAccepted { get; private set; }

    public Costumer Costumer { get; private set; }
    public Provider Provider { get; private set; }
    public IReadOnlyCollection<BudgetItem> BudgetItems { get; private set; } 

    protected Budget() { }

    public void Update(Budget budget)
    {

        if (CostumerId != budget.CostumerId)
        {
            CostumerId = budget
                .CostumerId
                .ValidateGuid();
        }

        if (ProviderId != budget.ProviderId)
        {
            ProviderId = budget
                .ProviderId
                .ValidateGuid();
        }

        if (Total != budget.Total)
        {
            Total = budget
                .Total
                .ValidateDecimal();
        }

        if (Deadline != budget.Deadline)
        {
            Deadline = budget.Deadline;
        }

        if(!Type.Equals(budget.Type))
        {
            Type = budget.Type;
        }

        IsAccepted = budget.IsAccepted;
    }

    public static Budget Create(
        Guid costumerId,
        Guid providerId,
        DateTime deadline,
        BudgetType type
    )
    {
        return new Budget
        {
            CostumerId = costumerId.ValidateGuid(),
            ProviderId = providerId.ValidateGuid(),
            Deadline = deadline,
            Type = type
        };
    }
}