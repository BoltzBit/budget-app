using Budget.Application.Services;
using Budget.Core.Domain.Entities;
using Budget.Core.Interfaces.Services;
using MediatR;

namespace Budget.Application.Features.Commands;

public class CreateProviderCommand : IRequest<bool>
{
    public required string ProviderName { get; set; }
    public required string Phone { get; set; }
    public required string Description { get; set; }
}

public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, bool>
{
    private readonly IProviderService _providerService;

    public CreateProviderCommandHandler(ProviderService providerService)
    {
        _providerService = providerService;
    }

    public async Task<bool> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
    {
        var provider = Provider.Create(
            request.ProviderName,
            request.Phone,
            request.Description
        );

        await _providerService.InsertAsync(provider);

        return true;
    }
}