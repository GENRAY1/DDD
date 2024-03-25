using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Models;
using UserService.Application.Abstractions.Commands;

namespace UserService.Infrastructure.Bus.Consumers.User;


/// <summary>
/// Класс подписчик на очередь сообщений добавляющий пользователя. ExchangeType - fanout 
/// </summary>
/// <param name="mediator"></param>
/// <param name="logger"></param>
public class UserCreatedConsumer(IMediator mediator, ILogger<UserCreatedConsumer> logger) : IConsumer<UserCreated>
{
    /// <summary>
    /// Метод обработчик 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public Task Consume(ConsumeContext<UserCreated> context)
    {
        //логирование
        logger.LogInformation("Принята информация по шине: {LastName} {FirstName}", context.Message.LastName,
            context.Message.FirstName);
        
        //отправляем команду на добавление пользователя
        return mediator.Send(new AddUserCommand(context.Message.FirstName, context.Message.LastName,
            context.Message.PhoneNumber, context.Message.Email, context.Message.Patronymic));
    }
}