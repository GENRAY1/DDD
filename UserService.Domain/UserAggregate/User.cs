using System.Text.RegularExpressions;
using UserService.Domain.Abstractions;
using UserService.Domain.OrganizationAggregate;
using UserService.Domain.UserAggregate.Exceptions;

namespace UserService.Domain.UserAggregate;

public class User : AggregateRoot
{
    public static Regex RegexEmail => new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    public static Regex RegexPhoneNumber => new Regex(@"^\+\d{11}$");

    public const int MaxFirstNameLength = 50;
    public const int MinFirstNameLength = 3;

    public const int MaxLastNameLength = 50;
    public const int MinLastNameLength = 3;

    public const int MaxPatronymicLength = 50;
    public const int MinPatronymicLength = 3;
    private User(
        Guid id,
        Guid? organizationId,
        string firstName,
        string lastName,
        string? patronymic,
        string email,
        string phoneNumber
    ) : base(id)
    {
        OrganizationId = organizationId;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public string FirstName { get; private init; }
    public string LastName { get; private init; }
    public string? Patronymic { get; private init; }
    public string PhoneNumber { get; private init; }
    public string Email { get; private init; }
    public Guid? OrganizationId { get; private set; }

    public void SetToOrganization(Organization organization)
    {
        OrganizationId = organization.Id;
    }
    public static User Create(
        Guid id,
        string firstName,
        string lastName,
        string? patronymic,
        string email,
        string phoneNumber,
        Guid? organizationId = null)
    {
        if (firstName.Length is < MinFirstNameLength or > MaxFirstNameLength)
            throw new IncorrectFirstNameException(MinFirstNameLength, MaxFirstNameLength);
        if (lastName.Length is < MinLastNameLength or > MaxLastNameLength)
            throw new IncorrectLastNameException(MinLastNameLength, MaxLastNameLength);
        if (!string.IsNullOrEmpty(patronymic) && patronymic.Length is < MinPatronymicLength or > MaxPatronymicLength)
            throw new IncorrectPatronymicException(MinPatronymicLength, MaxPatronymicLength);
        if (!RegexEmail.IsMatch(email))
            throw new IncorrectEmailException();
        if (!RegexPhoneNumber.IsMatch(phoneNumber))
            throw new IncorrectPhoneNumberException();
        
        return new User(id, organizationId ,firstName, lastName, patronymic, email, phoneNumber);
    }
}