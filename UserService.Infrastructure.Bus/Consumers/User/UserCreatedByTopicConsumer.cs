using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Models;
using UserService.Application.Abstractions.Commands;

namespace UserService.Infrastructure.Bus.Consumers.User;

/// <summary>
/// Класс подписчик на очередь сообщений добавляющий пользователя. ExchangeType - topic 
/// </summary>
/// <param name="mediator"></param>
/// <param name="logger"></param>
public class UserCreatedByTopicConsumer(IMediator mediator, ILogger<UserCreatedByTopicConsumer> logger) : IConsumer<UserCreatedByTopic>
{
    /// <summary>
    /// Метод обработчик 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public Task Consume(ConsumeContext<UserCreatedByTopic> context)
    {
        //логирование
        logger.LogInformation("(Topic) Принята информация по шине: {LastName} {FirstName}", context.Message.LastName,
            context.Message.FirstName);
        
        //отправляем команду на добавление пользователя
        return mediator.Send(new AddUserCommand(context.Message.FirstName, context.Message.LastName,
            context.Message.PhoneNumber, context.Message.Email, context.Message.Patronymic));
    }
}