using App.Core.Consts.Users;
using App.Core.Models.SystemBase.BaseClass;
using System;

namespace App.Core.Models.SystemBase.Roles.ViewModel
{
    public class SystemRoleInfo : BaseEntityInfo
    {
        public Guid systemRoleToken { get; set; }
        public string systemRoleName { get; set; }
        public EnumUserType systemRoleUserType { get; set; }
        public bool systemRoleCanUseDefault { get; set; }
    }
}