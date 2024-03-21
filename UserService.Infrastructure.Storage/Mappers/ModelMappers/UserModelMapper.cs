using UserService.Domain.UserAggregate;
using UserService.Infrastructure.Storage.Models;

namespace UserService.Infrastructure.Storage.Mappers.ModelMappers;

public class UserModelMapper
{
    public static UserModel Map(User userAggregate, UserModel userModel)
    {
        userModel.FirstName = userAggregate.FirstName;
        userModel.LastName = userAggregate.LastName;
        userModel.Patronymic = userAggregate.Patronymic;
        userModel.Email = userAggregate.Email;
        userModel.PhoneNumber = userAggregate.PhoneNumber;
        
        if (userAggregate.OrganizationId.HasValue)
        {
            userModel.OrganizationId = userAggregate.OrganizationId;
        }
        return userModel;
    }
}