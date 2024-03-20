using UserService.Domain.Abstractions;
using UserService.Domain.OrganizationAggregate.Exceptions;

namespace UserService.Domain.OrganizationAggregate;

public class Organization(Guid id) : AggregateRoot(id)
{
    public const int MaxNameLength = 100;
    public const int MinNameLength = 3;
    
    private string _name;

    public string Name
    {
        get => _name;
        init
        {
            if(value.Length < MinNameLength || value.Length > MaxNameLength)
                throw new IncorrectOrgNameException(MinNameLength, MaxNameLength);
            _name = value;
        }
    }
}