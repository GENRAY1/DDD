using MediatR;
using UserService.Domain.UserAggregate;

namespace UserService.Application.Abstractions.Queries;

/// <summary>
/// Запрос на получение пользователей у указанной организации
/// </summary>
/// <param name="organizationId">Id организации</param>
/// <param name="skip">Количество записей которые нужно пропустить</param>
/// <param name="take">Количество записей которые нужно взять</param>
public class GetUsersQuery(Guid? organizationId, int skip, int take) : IRequest<ICollection<User>>
{
    /// <summary>
    /// Id организации
    /// </summary>
    public Guid? OrganizationId { get; } = organizationId;
    /// <summary>
    /// Количество записей которые нужно пропустить
    /// </summary>
    public int Skip { get; } = skip;
    /// <summary>
    /// Количество записей которые нужно взять
    /// </summary>
    public int Take { get; } = take;
}