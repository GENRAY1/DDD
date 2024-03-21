using RequestManager.Application.Abstractions.Dto;

namespace RequestManager.Application.Abstractions.Producers;

/// <summary>
/// Интерфейс генерирующий отправку сообщения по шине
/// </summary>
public interface IUserProducer
{
    /// <summary>
    /// Метод генерирующий отправку сообщения по шине
    /// </summary>
    /// <param name="userDto">Объект Dto пользователя для передачи между слоями</param>
    void ProduceUserCreate(UserDto userDto);
}