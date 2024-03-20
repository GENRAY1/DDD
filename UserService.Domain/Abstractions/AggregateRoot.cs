namespace UserService.Domain.Abstractions;

public abstract class AggregateRoot(Guid id)
{
    public Guid Id => id;
}