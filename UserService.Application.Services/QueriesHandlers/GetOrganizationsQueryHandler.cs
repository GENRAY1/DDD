using MediatR;
using UserService.Application.Abstractions.Queries;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.OrganizationAggregate;

namespace UserService.Application.Services.QueriesHandlers;

public class GetOrganizationsQueryHandler(IOrganizationRepository organizationStore) : IRequestHandler<GetOrganizationsQuery, ICollection<Organization>>
{
    public Task<ICollection<Organization>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
    {
        return organizationStore.FindAsync(request.Skip, request.Take);
    }
}