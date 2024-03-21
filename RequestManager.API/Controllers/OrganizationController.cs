using MediatR;
using Microsoft.AspNetCore.Mvc;
using RequestManager.API.Contracts.Organization;
using RequestManager.Application.Abstractions.Commands;

namespace RequestManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrganizationController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddOrganization(OrganizationPostRequest request, CancellationToken cancellationToken = default)
    {
        await mediator.Send(new AddOrganizationCommand(name: request.Name), cancellationToken);
        return Ok();
    }
}