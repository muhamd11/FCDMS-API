using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;
using AutoMapper;

namespace Api.MappingProfiles.Users
{
    public class UsersModulesProfile : Profile
    {
        public UsersModulesProfile()
        {
            CreateMap<User, UserAddOrUpdateDTO>().ReverseMap();
            CreateMap<UserSignUpDto, UserAddOrUpdateDTO>().ReverseMap();
        }
    }
}