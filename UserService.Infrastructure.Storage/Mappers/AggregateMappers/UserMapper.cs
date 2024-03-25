using UserService.Domain.OrganizationAggregate;
using UserService.Domain.UserAggregate;
using UserService.Infrastructure.Storage.Models;

namespace UserService.Infrastructure.Storage.Mappers.AggregateMappers;

public class UserMapper
{
    public static User Map(UserModel model)
    {
        Guid? organizationId = null;
        if (model.Organization != null)
        {
            organizationId = model.Organization.Id;
        }
        
        var user = User.Create(
            model.Id,
            model.FirstName,
            model.LastName,
            model.Patronymic,
            model.Email,
            model.PhoneNumber,
            organizationId);
        
        return user;
    }
}