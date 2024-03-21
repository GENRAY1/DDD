using MediatR;
using UserService.Domain.UserAggregate;

namespace UserService.Application.Abstractions.Queries;

public class GetUsersWithoutOrganizationQuery(int skip, int take) : IRequest<ICollection<User>>
{
    /// <summary>
    /// Количество записей которые нужно пропустить
    /// </summary>
    public int Skip { get; } = skip;
    /// <summary>
    /// Количество записей которые нужно взять
    /// </summary>
    public int Take { get; } = take;
}