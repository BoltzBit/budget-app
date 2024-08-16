using Budget.Core.Domain.Enuns;
using Budget.Core.Dto;
using MediatR;

namespace Budget.Application.Features.Commands;

public class CreateBudgetCommand : IRequest<bool>
{
    public required int ProviderGuid { get; set; }
    public required string ClientName { get; set; }
    public required string Phone { get; set; }
    public required BudgetType Type { get; set; }
    public required DateTime DeadLine { get; set; }
    public required IEnumerable<BudgetItemDto> Items { get; set; }
}

public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, bool>
{
    public Task<bool> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
