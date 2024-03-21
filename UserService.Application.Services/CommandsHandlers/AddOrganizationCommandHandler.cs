using MediatR;
using UserService.Application.Abstractions.Commands;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.OrganizationAggregate;

namespace UserService.Application.Services.CommandsHandlers;

public class AddOrganizationCommandHandler(IOrganizationRepository repository):IRequestHandler<AddOrganizationCommand>
{
    public Task Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
    {
        return repository.AddAsync(new Organization(Guid.NewGuid())
        {
            Name = request.Name
        });
    }
}


