using UserService.Domain.OrganizationAggregate;
using UserService.Infrastructure.Storage.Models;

namespace UserService.Infrastructure.Storage.Mappers.ModelMappers;

public class OrganizationModelMapper
{
    public static OrganizationModel Map(Organization organizationAggregate, OrganizationModel organizationModel)
    {
        organizationModel.Name = organizationAggregate.Name;
        return organizationModel;
    }
}
