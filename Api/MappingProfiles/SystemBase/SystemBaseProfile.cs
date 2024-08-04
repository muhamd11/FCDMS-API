using App.Core.Models.SystemBase.LogActions;
using App.Core.Models.SystemBase.LogActions.DTO;
using App.Core.Models.SystemBase.Roles;
using App.Core.Models.SystemBase.Roles.DTO;
using AutoMapper;

namespace Api.MappingProfiles.Authorizations
{
    public class SystemBaseProfile : Profile
    {
        public SystemBaseProfile()
        {
            CreateMap<SystemRole, SystemRoleAddOrUpdateDTO>().ReverseMap();
            //CreateMap<LogAction, LogActionAddOrUpdateDTO>().ReverseMap();
        }
    }
}