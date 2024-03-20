namespace UserService.Application.Abstractions.Exceptions;

public class OrganizationNotFoundException(Guid id) : Exception($"Organization with id {id} not found")
{
    public Guid Id = id;
}
