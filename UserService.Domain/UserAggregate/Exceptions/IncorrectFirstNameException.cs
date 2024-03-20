namespace UserService.Domain.UserAggregate.Exceptions;

public class IncorrectFirstNameException(int minlength, int maxlength)
    : Exception($"Invalid property FirstName, the minimum number of characters should be {minlength}" +
                $" and the maximum number of characters should be {maxlength} characters");
