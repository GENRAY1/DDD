using UserService.Domain.Abstractions;
using UserService.Domain.OrganizationAggregate.Exceptions;

namespace UserService.Domain.OrganizationAggregate;

public class Organization: AggregateRoot
{
    public const int MaxNameLength = 100;
    public const int MinNameLength = 3;
    private Organization(Guid id, string name):base(id)
    {
        Name = name;
    }

    public static Organization Create(Guid id, string name)
    {
        if(name.Length < MinNameLength || name.Length > MaxNameLength)
            throw new IncorrectOrgNameException(MinNameLength, MaxNameLength);
        return new Organization(id, name);
    }
    
    public string Name { get; private init; }
}