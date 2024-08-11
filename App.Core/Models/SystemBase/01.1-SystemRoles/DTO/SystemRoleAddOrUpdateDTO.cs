using App.Core.Consts.SystemBase;
using App.Core.Consts.Users;

namespace App.Core.Models.SystemBase.Roles.DTO
{
    public class SystemRoleAddOrUpdateDTO
    {
        public Guid systemRoleToken { get; set; }
        public string systemRoleName { get; set; }
        public string systemRoleDescription { get; set; }
        public EnumUserType systemRoleUserTypeToken { get; set; }
        public bool systemRoleCanUseDefault { get; set; }
        public string? fullCode { get; set; }

        public EnumActivationType activationType { get; set; }
    }
}