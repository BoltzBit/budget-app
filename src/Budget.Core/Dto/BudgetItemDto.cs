using Budget.Core.Domain.Enuns;

namespace Budget.Core.Dto;

public record BudgetItemDto(string Description, BudgetItemType BudgetItemType);
