namespace Shared.Models;

public class UserCreated
{
    /// <summary>
    /// Конструктов
    /// </summary>
    /// <param name="firstName">Имя пользователя</param>
    /// <param name="lastName">Фамилия пользователя</param>
    /// <param name="phoneNumber">Номер телефона пользователя</param>
    /// <param name="email">Адрес электронной почты пользователя</param>
    /// <param name="patronymic">Отчество пользователя</param>
    public UserCreated(string firstName, string lastName, string phoneNumber, string email, string? patronymic = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string FirstName { get; }
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string LastName { get; }
    /// <summary>
    /// Отчество пользователя
    /// </summary>
    public string? Patronymic { get; }
    /// <summary>
    /// Номер телефона пользователя
    /// </summary>
    public string PhoneNumber { get; }
    /// <summary>
    /// Адрес электронной почты пользователя
    /// </summary>
    public string Email { get; }
}