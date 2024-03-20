namespace UserService.API.Contracts;

public record class UserResponseModel(Guid Id, string FirstName, string LastName, string? Patronymic, string PhoneNumber, string Email);