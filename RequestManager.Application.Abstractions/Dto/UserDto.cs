namespace RequestManager.Application.Abstractions.Dto;

public class UserDto
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="firstName">Имя</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="phoneNumber">Номер телефона</param>
    /// <param name="email">Почта</param>
    /// <param name="patronymic">Отчество</param>
    public UserDto(string firstName, string lastName, string phoneNumber, string email, string? patronymic = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; }

    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; }
}