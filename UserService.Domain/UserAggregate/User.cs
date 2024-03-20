using System.Text.RegularExpressions;
using UserService.Domain.Abstractions;
using UserService.Domain.OrganizationAggregate;
using UserService.Domain.UserAggregate.Exceptions;

namespace UserService.Domain.UserAggregate;

public class User(Guid id):AggregateRoot(id)
{

    public static Regex RegexEmail => new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    public static Regex RegexPhoneNumber => new Regex(@"^\+\d{11}$");
    
    public const int MaxFirstNameLength = 50;
    public const int MinFirstNameLength = 3;
    
    public const int MaxLastNameLength = 50;
    public const int MinLastNameLength = 3;
    
    public const int MaxPatronymicLength = 50;
    public const int MinPatronymicLength = 3;
    
    private string _firstName;
    private string _lastName;
    private string? _patronymic;
    private string _phoneNumber;
    private string _email;
    
    public Guid? OrganizationId { get; private set; }

    public void SetToOrganization(Organization organization)
    {
        OrganizationId = organization.Id;
    }
    
    public required string FirstName
    {
        get => _firstName;
        init
        {
            if(value.Length is < MinFirstNameLength or > MaxFirstNameLength)
                throw new IncorrectFirstNameException(MinFirstNameLength, MaxFirstNameLength);
            _firstName = value;
        }
    }
    
    public required string LastName
    {
        get => _lastName;
        init
        {
            if (value.Length is < MinLastNameLength or > MaxLastNameLength)
                throw new IncorrectLastNameException(MinLastNameLength, MaxLastNameLength);
            _lastName = value;
        }
    }

    public required string? Patronymic
    {
        get => _patronymic;
        init
        {
            if (!string.IsNullOrEmpty(value) && value.Length is < MinPatronymicLength or > MaxPatronymicLength)
                throw new IncorrectPatronymicException(MinPatronymicLength, MaxPatronymicLength);
            _patronymic = value;
        }
    }

    public string PhoneNumber
    {
        get=> _phoneNumber; 
        init
        {
            if(!RegexPhoneNumber.IsMatch(value))
                throw new IncorrectPhoneNumberException();
            _phoneNumber = value;
        }
        
    }

    public string Email
    {
        get => _email;
        init
        {
            if(!RegexEmail.IsMatch(value))
                throw new IncorrectEmailException();
            _email = value;
            
        }
    }
}