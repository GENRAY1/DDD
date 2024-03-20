namespace UserService.API.Contracts.User;

public record UserGetResponse(Guid Id, string FirstName, string LastName, string? Patronymic, string PhoneNumber, string Email);