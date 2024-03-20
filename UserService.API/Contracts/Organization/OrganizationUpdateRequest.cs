namespace UserService.API.Contracts.Organization;

public record OrganizationUpdateRequest(Guid? Userid, Guid? OrganizationId);