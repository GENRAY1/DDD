using MediatR;
using RequestManager.Application.Abstractions.Commands;
using RequestManager.Application.Abstractions.Dto;
using RequestManager.Application.Abstractions.Producers;

namespace RequestManager.Application.Services.CommandsHandlers;

/// <summary>
/// Обработчик команды по добавлению пользователя
/// </summary>
/// <param name="producer">Интерфейс генерирующий отправку сообщения по шине</param>
public class AddUserByHeadersCommandHandler(IUserProducers producer) : IRequestHandler<AddUserByHeadersCommand>
{
    /// <summary>
    /// Метод обработчик команды по добавлению пользователя
    /// </summary>
    /// <param name="request">Команда для добавления пользователя</param>
    /// <param name="cancellationToken">Токен для отмены операции</param>
    /// <returns>Task</returns>
    public Task Handle(AddUserByHeadersCommand request, CancellationToken cancellationToken)
    {
        //отправляем сообщение по шине
        producer.UserCreateByHeadersProducer(new UserDto(request.FirstName, request.LastName, request.PhoneNumber, request.Email,
            request.Patronymic));
        
        //возвращаем удачный результат задачи
        return Task.CompletedTask;
    }
}