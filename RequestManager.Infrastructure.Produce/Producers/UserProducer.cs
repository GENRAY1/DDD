using MassTransit;
using Microsoft.Extensions.Logging;
using RequestManager.Application.Abstractions.Producers;
using RequestManager.Application.Abstractions.Dto;
using Shared.Models;

namespace RequestManager.Infrastructure.Produce.Producers;

public class UserProducer(IPublishEndpoint publishEndpoint, ILogger<UserProducer> logger) : IUserProducer
{
    /// <summary>
    /// Метод генерирующий отправку сообщения по шине
    /// </summary>
    /// <param name="userDto">Объект Dto пользователя для передачи между слоями</param>
    public void ProduceUserCreate(UserDto userDto)
    {
        //Логируем отправку
        logger.LogInformation("Отправка данных пользователя по шине: {LastName} {FirstName}",
            userDto.LastName,
            userDto.FirstName);

        //Публикуем сообщение
        publishEndpoint.Publish(new UserCreated(userDto.FirstName, userDto.LastName, userDto.PhoneNumber,
            userDto.Email,
            userDto.Patronymic));
    }
}