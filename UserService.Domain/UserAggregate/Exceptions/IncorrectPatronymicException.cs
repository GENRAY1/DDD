namespace UserService.Domain.UserAggregate.Exceptions;

public class IncorrectPatronymicException(int minlength, int maxlength)
    :Exception($"Invalid property Patronymic, the minimum number of characters should be {minlength}" +
               $" and the maximum number of characters should be {maxlength} characters");