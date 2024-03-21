using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Models;
using UserService.Application.Abstractions.Commands;

namespace UserService.Infrastructure.Bus.Consumers;

public class OrganizationCreatedConsumer(IMediator mediator, ILogger<OrganizationCreatedConsumer> logger): IConsumer<OrganizationCreated>
{
    public Task Consume(ConsumeContext<OrganizationCreated> context)
    {
        logger.LogInformation("Принята информация по шине: {Name}", context.Message.Name);
        return mediator.Send(new AddOrganizationCommand(context.Message.Name));
    }
}