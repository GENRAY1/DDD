using UserService.Domain.UserAggregate;
using UserService.Infrastructure.Storage.Models;

namespace UserService.Infrastructure.Storage.Mappers.ModelMappers;

public class UserModelMapper
{
    public static UserModel Map(User user)
    {
        return new UserModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Patronymic = user.Patronymic,
            PhoneNumber = user.PhoneNumber
        };
    }
}