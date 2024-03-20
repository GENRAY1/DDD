namespace UserService.Application.Abstractions.Exceptions;

public class UserNotFoundException(Guid id) : Exception($"User with id {id} not found")
{
    public Guid Id = id;
}
