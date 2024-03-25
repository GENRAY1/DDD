namespace Shared.Models;

public class UserCreatedByTopic(string firstName, string lastName, string phoneNumber, string email, string? patronymic = null)
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string FirstName { get; } = firstName;

    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string LastName { get; } = lastName;

    /// <summary>
    /// Отчество пользователя
    /// </summary>
    public string? Patronymic { get; } = patronymic;

    /// <summary>
    /// Номер телефона пользователя
    /// </summary>
    public string PhoneNumber { get; } = phoneNumber;

    /// <summary>
    /// Адрес электронной почты пользователя
    /// </summary>
    public string Email { get; } = email;
}