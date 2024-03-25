using MassTransit;
using Microsoft.Extensions.Logging;
using RequestManager.Application.Abstractions.Producers;
using RequestManager.Application.Abstractions.Dto;
using Shared.Models;

namespace RequestManager.Infrastructure.Produce.Producers;

public class UserProducers(IPublishEndpoint publishEndpoint, ILogger<UserProducers> logger) : IUserProducers
{
    /// <summary>
    /// Метод генерирующий отправку сообщения по шине. ExchangeType - fanout
    /// </summary>
    /// <param name="userDto">Объект Dto пользователя для передачи между слоями</param>
    public void UserCreateProducer(UserDto userDto)
    {
        //Логируем отправку
        logger.LogInformation("(Fanout) Отправка данных пользователя по шине: {LastName} {FirstName}",
            userDto.LastName,
            userDto.FirstName);
        //Публикуем сообщение
        publishEndpoint.Publish(new UserCreated(userDto.FirstName, userDto.LastName, userDto.PhoneNumber,
            userDto.Email,
            userDto.Patronymic));
    }
    
    /// <summary>
    /// Метод генерирующий отправку сообщения по шине. ExchangeType - topic
    /// </summary>
    /// <param name="userDto">Объект Dto пользователя для передачи между слоями</param>
    public void UserCreateByTopicProducer(UserDto userDto)
    {
        //Логируем отправку
        logger.LogInformation("(Topic) Отправка данных пользователя по шине: {LastName} {FirstName}",
            userDto.LastName,
            userDto.FirstName);
        //Публикуем сообщение
        publishEndpoint.Publish(new UserCreatedByTopic(userDto.FirstName, userDto.LastName, userDto.PhoneNumber, userDto.Email, userDto.Patronymic),
            context =>
            {
                context.SetRoutingKey("user.create");
            });
    }
    /// <summary>
    /// Метод генерирующий отправку сообщения по шине. ExchangeType - headers
    /// </summary>
    /// <param name="userDto">Объект Dto пользователя для передачи между слоями</param>
    public void UserCreateByHeadersProducer(UserDto userDto)
    {
        //Логируем отправку
        logger.LogInformation("(Headers) Отправка данных пользователя по шине: {LastName} {FirstName}",
            userDto.LastName,
            userDto.FirstName);
        //Публикуем сообщение
        publishEndpoint.Publish(new UserCreatedByHeaders(userDto.FirstName, userDto.LastName, userDto.PhoneNumber, userDto.Email, userDto.Patronymic),
            context =>
            {
                context.Headers.Set("action", "create");
                context.Headers.Set("entity", "user");
            });
    }
    
    /// <summary>
    /// Метод генерирующий отправку сообщения по шине. ExchangeType - direct
    /// </summary>
    /// <param name="userDto">Объект Dto пользователя для передачи между слоями</param>
    public void UserCreateByDirectProducer(UserDto userDto)
    {
        //Логируем отправку
        logger.LogInformation("(Direct) Отправка данных пользователя по шине: {LastName} {FirstName}",
            userDto.LastName,
            userDto.FirstName);
        //Публикуем сообщение
        publishEndpoint.Publish(new UserCreatedByDirect(userDto.FirstName, userDto.LastName, userDto.PhoneNumber, userDto.Email, userDto.Patronymic),
            context =>
            {
                context.SetRoutingKey("user-created");
            });
    }
}