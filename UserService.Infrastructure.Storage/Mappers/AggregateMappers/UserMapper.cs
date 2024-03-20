using UserService.Domain.UserAggregate;
using UserService.Infrastructure.Storage.Models;

namespace UserService.Infrastructure.Storage.Mappers.AggregateMappers;

public class UserMapper
{
    public static User Map(UserModel model)
    {
        var user = new User(model.Id)
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Patronymic = model.Patronymic,
            PhoneNumber = model.PhoneNumber
        };
        /*TODO
        if (model.Organization != null)
        {
            user.SetToOrganization(model.Organization);    
        }*/
        
        return user;
    }
}