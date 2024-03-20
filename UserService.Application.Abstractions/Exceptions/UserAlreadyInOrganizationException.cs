namespace UserService.Application.Abstractions.Exceptions;

public class UserAlreadyInOrganizationException(Guid idUser, string name)
    : Exception($"The user with id {idUser} is already a member of the {name} organization")
{
    public Guid IdUser = idUser;
    public readonly string Name = name;
}