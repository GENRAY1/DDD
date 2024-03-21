using UserService.Domain.OrganizationAggregate;
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
        
        if (model.Organization != null)
        {
            Organization organizationAggregate = OrganizationMapper.Map(model.Organization);
            user.SetToOrganization(organizationAggregate);
        }
        
        return user;
    }
}