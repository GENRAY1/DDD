using UserService.Domain.OrganizationAggregate;
using UserService.Infrastructure.Storage.Models;

namespace UserService.Infrastructure.Storage.Mappers.AggregateMappers;

public class OrganizationMapper
{

    public static Organization Map(OrganizationModel model)
    {
        var org = Organization.Create(
            model.Id,
            model.Name
        );
        return org;
    }
    
}