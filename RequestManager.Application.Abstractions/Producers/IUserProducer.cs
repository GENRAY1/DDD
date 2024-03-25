using RequestManager.Application.Abstractions.Dto;

namespace RequestManager.Application.Abstractions.Producers;

/// <summary>
/// Интерфейс генерирующий отправку сообщения по шине
/// </summary>
public interface IUserProducers
{
    /// <summary>
    /// Метод генерирующий отправку сообщения по шине
    /// </summary>
    /// <param name="userDto">Объект Dto пользователя для передачи между слоями</param>
    void UserCreateProducer(UserDto userDto);
    void UserCreateByTopicProducer(UserDto userDto);
    void UserCreateByHeadersProducer(UserDto userDto);
    void UserCreateByDirectProducer(UserDto userDto);
}