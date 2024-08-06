using App.Core.Consts.Users;
using App.Core.Models.SystemBase.BaseClass;

namespace App.Core.Models.SystemBase.Roles.ViewModel
{
    public class SystemRoleInfo : BaseEntityInfo
    {
        public Guid systemRoleToken { get; set; }
        public string systemRoleName { get; set; }
        public EnumUserType systemRoleUserTypeToken { get; set; }
        public bool systemRoleCanUseDefault { get; set; }
    }
}