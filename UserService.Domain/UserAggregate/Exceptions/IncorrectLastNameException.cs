namespace UserService.Domain.UserAggregate.Exceptions;

public class IncorrectLastNameException
    (int minlength, int maxlength)
    :Exception($"Invalid property LastName, the minimum number of characters should be {minlength}" +
               $" and the maximum number of characters should be {maxlength} characters");