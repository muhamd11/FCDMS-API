using App.Core.Models.Users;
using AutoMapper;

namespace Api.MappingProfiles.Users
{
    public class UsersModulesProfile : Profile
    {
        public UsersModulesProfile()
        {
            CreateMap<User, UserAddOrUpdateDTO>().ReverseMap();
        }
    }
}