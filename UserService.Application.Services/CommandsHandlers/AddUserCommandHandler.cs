using MediatR;
using UserService.Domain.Abstractions.Repositories;
using UserService.Application.Abstractions.Commands;
using UserService.Domain.UserAggregate;
namespace UserService.Application.Services.CommandsHandlers;

/// <summary>
/// Класс обработчик команды добавления пользователя в базу данных
/// </summary>
/// <param name="userStore"></param>
public class AddUserCommandHandler(IUserRepository userStore) : IRequestHandler<AddUserCommand>
{
    /// <summary>
    /// обработчик команды
    /// </summary>
    /// <param name="request">Команда для добавления пользователя</param>
    /// <param name="cancellationToken">Распространяет уведомление о том, что операции следует отменить.</param>
    /// <returns></returns>
    public Task Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(
            Guid.NewGuid(),
            request.FirstName,
            request.LastName,
            request.Patronymic,
            request.Email,
            request.PhoneNumber);
        
        return userStore.AddAsync(user);
    }
}