namespace UserService.Application.Abstractions.Exceptions;

public class UserAlreadyInOrganizationException(Guid idUser, Guid organizationId)
    : Exception($"The user with id {idUser} is already a member of the {organizationId} organization")
{
    public Guid IdUser = idUser;
    public readonly Guid OrganizationId = organizationId;
}