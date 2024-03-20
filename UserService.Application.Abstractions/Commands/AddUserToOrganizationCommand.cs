using MediatR;

namespace UserService.Application.Abstractions.Commands;

/// <summary>
/// Команда на связывание пользователя с организацией 
/// </summary>
/// <param name="userId"></param>
/// <param name="organizationId"></param>
public class AddUserToOrganizationCommand(Guid userId, Guid organizationId) : IRequest
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid UserId { get; } = userId;
    
    /// <summary>
    /// Id организации
    /// </summary>
    public Guid OrganizationId { get; } = organizationId;
}