using App.Core.Consts.Users;
using App.Core.Models.General.BaseRequstModules;

namespace App.Core.Models.SystemBase.Roles.DTO
{
    public class SystemRoleSearchDto : BaseSearchDto
    {
        public EnumUserType? systemRoleUserTypeToken { get; set; }
    }
}