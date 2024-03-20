using UserService.Domain.OrganizationAggregate;
using UserService.Infrastructure.Storage.Models;

namespace UserService.Infrastructure.Storage.Mappers.ModelMappers;

public class OrganizationModelMapper
{
    public static OrganizationModel Map(Organization user)
    {
        return new OrganizationModel
        {
            Id = user.Id,
            Name = user.Name
        };
    }
}
