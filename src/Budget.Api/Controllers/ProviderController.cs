using Microsoft.AspNetCore.Mvc;
using MediatR;
using Budget.Application.Features.Commands;

namespace Budget.Api.Controllers;

[ApiController]
[Route("provider")]
public class ProviderController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProviderAsync([FromBody] CreateProviderCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}