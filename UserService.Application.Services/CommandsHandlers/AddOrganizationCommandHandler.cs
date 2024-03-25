using MediatR;
using UserService.Application.Abstractions.Commands;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.OrganizationAggregate;

namespace UserService.Application.Services.CommandsHandlers;

public class AddOrganizationCommandHandler(IOrganizationRepository repository):IRequestHandler<AddOrganizationCommand>
{
    public Task Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
    {
        Organization org = Organization.Create(Guid.NewGuid(), request.Name);
        return repository.AddAsync(org);
    }
}


