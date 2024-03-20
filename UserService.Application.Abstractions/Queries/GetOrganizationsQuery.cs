using MediatR;
using UserService.Domain.OrganizationAggregate;

namespace UserService.Application.Abstractions.Queries;

/// <summary>
/// Класс запроса для получения организаций
/// </summary>
/// <param name="skip">Количество записей которые нужно пропустить</param>
/// <param name="take">Количество записей которые нужно взять</param>
public class GetOrganizationsQuery(int skip, int take) : IRequest<ICollection<Organization>>
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