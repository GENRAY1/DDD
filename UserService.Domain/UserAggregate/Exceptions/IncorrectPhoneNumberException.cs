namespace UserService.Domain.UserAggregate.Exceptions;

public class IncorrectPhoneNumberException()
    :Exception($"Invalid property PhoneNumber. The phone number must contain 11 digits");