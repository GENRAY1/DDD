using AutoMapper;
using UserService.Domain.UserAggregate;
using UserService.Infrastructure.Storage.Models;

namespace UserService.Infrastructure.Storage.Mapper.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserModel, User>()
            .ConstructUsing(x => new User (x.Id)
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Patronymic = x.Patronymic,
                PhoneNumber = x.PhoneNumber
            });
        CreateMap<User, UserModel>();
    }
}