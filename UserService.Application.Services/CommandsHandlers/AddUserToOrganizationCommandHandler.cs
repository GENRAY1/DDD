using MediatR;
using Microsoft.Extensions.Logging;
using UserService.Domain.Abstractions.Repositories;
using UserService.Application.Abstractions.Commands;
using UserService.Application.Abstractions.Exceptions;

namespace UserService.Application.Services.CommandsHandlers;

/// <summary>
/// Обработчик запроса на связывание пользователя с организацией 
/// </summary>
/// <param name="userStore">Интерфейс репозитория управления пользователями</param>
/// <param name="organizationStore">Интерфейс репозитория управления организациями</param>
/// <param name="logger">Интерфейс логирования</param>
public class AddUserToOrganizationCommandHandler(
    IUserRepository userStore,
    IOrganizationRepository organizationStore,
    ILogger<AddUserToOrganizationCommandHandler> logger) : IRequestHandler<AddUserToOrganizationCommand>
{
    /// <summary>
    /// Метод обработчик запроса
    /// </summary>
    /// <param name="request">Класс запроса на связывание пользователя с организацией</param>
    /// <param name="cancellationToken">Токен для прерывания операции</param>
    /// <exception cref="UserNotFoundException">Исключение использующийся в случае отсутствию пользователя
    /// с искомым Id</exception>
    /// <exception cref="UserAlreadyInOrganizationException">Исключение для ситуации если в организации
    /// пользователь с указанным id уже существует</exception>
    /// <exception cref="OrganizationNotFoundException">Исключение для ситуации когда не найдена организации
    /// по id</exception>
    public async Task Handle(AddUserToOrganizationCommand request, CancellationToken cancellationToken)
    {
        var user = await userStore.GetAsync(request.UserId);
        if (user == null) throw new UserNotFoundException(request.UserId);
        var organization = await organizationStore.GetAsync(request.OrganizationId);
        if (user.OrganizationId.HasValue)
        {
            var userOrganization = await organizationStore.GetAsync(user.OrganizationId.Value);
            throw new UserAlreadyInOrganizationException(user.Id, userOrganization!.Name);
        }

        if (organization == null) throw new OrganizationNotFoundException(request.OrganizationId);
        user.SetToOrganization(organization);
        logger.LogInformation("Пользователь {LastName} {FirstName} добавлен в организацию {OrgName}",
            user.LastName,
            user.FirstName, organization.Name);
        await userStore.UpdateAsync(user);
    }
}