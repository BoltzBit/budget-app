using BaseEntity = Budget.Core.Domain.Entities.Budget;

namespace Budget.Core.Interfaces.Services;

public interface IBudgetService
{
    Task<Guid> InsertAsync(BaseEntity budget);
}
