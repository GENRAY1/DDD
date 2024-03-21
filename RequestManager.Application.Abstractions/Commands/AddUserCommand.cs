using MediatR;
namespace RequestManager.Application.Abstractions.Commands
{
    /// <summary>
    /// Команда для добавления пользователя
    /// </summary>
    public class AddUserCommand : IRequest
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="email">Почта</param>
        /// <param name="patronymic">Отчество</param>
        public AddUserCommand(string firstName, string lastName, string phoneNumber, string email,
            string? patronymic = null)
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
}