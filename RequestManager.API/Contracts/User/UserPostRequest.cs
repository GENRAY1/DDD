namespace RequestManager.API.Contracts.User;

public record UserPostRequest(string FirstName, string LastName, string? Patronymic, string PhoneNumber, string Email);