using MediatR;

namespace RequestManager.Application.Abstractions.Commands
{
    /// <summary>
    /// Команда для добавления пользователя
    /// </summary>
    public class AddUserCommand(
        string firstName,
        string lastName,
        string phoneNumber,
        string email,
        string? patronymic = null) : IRequest
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; } = firstName;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; } = lastName;

        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; } = patronymic;

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; } = phoneNumber;

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; } = email;
    }
}