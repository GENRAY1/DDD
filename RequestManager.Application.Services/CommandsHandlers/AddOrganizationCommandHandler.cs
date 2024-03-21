using MediatR;
using RequestManager.Application.Abstractions.Commands;
using RequestManager.Application.Abstractions.Dto;
using RequestManager.Application.Abstractions.Producers;

namespace RequestManager.Application.Services.CommandsHandlers;

public class AddOrganizationCommandHandler(IOrganizationProducer producer): IRequestHandler<AddOrganizationCommand>
{
    public Task Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
    {
        producer.ProduceOrganizationCreate(new OrganizationDto(
            name:request.Name)
        );
        return Task.CompletedTask;
    }
}