using AutoMapper;
using UserService.Domain.OrganizationAggregate;
using UserService.Infrastructure.Storage.Models;

namespace UserService.Infrastructure.Storage.Mapper.Profiles;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<OrganizationModel, Organization>()
            .ConstructUsing(x => new Organization(x.Id)
            {
                Name = x.Name
            });
        CreateMap<Organization, OrganizationModel>();
    }
}