using MediatR;
using UserService.Application.Abstractions.Queries;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.UserAggregate;

namespace UserService.Application.Services.QueriesHandlers;

public class GetUsersWithoutOrganizationQueryHandler(IUserRepository userStore) : IRequestHandler<GetUsersWithoutOrganizationQuery, ICollection<User>> 
{
    public Task<ICollection<User>> Handle(GetUsersWithoutOrganizationQuery request, CancellationToken cancellationToken)
    {
        if (request.Skip < 0 && request.Take <= 0)
        {
            throw new Exception("Неккоректные параметры запроса");
        }
        
        return userStore.FindWithoutOrganizationAsync(request.Skip, request.Take);
    }
}