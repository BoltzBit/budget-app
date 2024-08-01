using Budget.Core.Domain.Utils;

namespace Budget.Core.Domain.Entities;

public class BudgetItem : BaseEntity
{
    public Guid BudgetId { get; private set; }
    public string Description { get; private set; }
    public int Type {  get; private set; }
    public decimal Price { get; private set; }
    
    protected BudgetItem() {}

    public void Update(BudgetItem budgetItemUpdate)
    {

        if(Description != budgetItemUpdate.Description)
        {
            Description = budgetItemUpdate
                .Description
                .ValidateString(Constants.MinDescriptionLength, Constants.MaxDescriptionLength);
        }

        if(Type != budgetItemUpdate.Type)
        {
            Type = budgetItemUpdate
                .Type
                .ValidateInt();
        }

        if(Price != budgetItemUpdate.Price)
        {
            Price = budgetItemUpdate
                .Price
                .ValidateDecimal();
        }
    }

    public static BudgetItem Create(
    Guid budgetId, 
    string description,
    int type,
    decimal price
    )
    {
        return new BudgetItem
        {
            BudgetId = budgetId.ValidateGuid(),
            Description = description.ValidateString(Constants.MinDescriptionLength, Constants.MaxDescriptionLength),
            Type = type.ValidateInt(),
            Price = price
        };
    }
}
