using MediatR;
using UserService.Application.Abstractions.Queries;
using UserService.Application.Abstractions.Exceptions;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.UserAggregate;

namespace UserService.Application.Services.QueriesHandlers;

public class GetUsersQueryHandler(IUserRepository userStore, IOrganizationRepository organizationStore)
    : IRequestHandler<GetUsersQuery, ICollection<User>>
{
    public async Task<ICollection<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        if (request.OrganizationId.HasValue)
        {
            var organization = await organizationStore.GetAsync(request.OrganizationId.Value);
            if (organization == null) throw new OrganizationNotFoundException(request.OrganizationId.Value);
        }

        var users = await userStore.FindAsync(request.OrganizationId, request.Skip, request.Take);
        return users;
    }
}