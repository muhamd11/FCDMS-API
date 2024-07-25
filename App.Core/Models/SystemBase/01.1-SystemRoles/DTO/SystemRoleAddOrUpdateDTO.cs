using App.Core.Consts.Users;
using App.Core.Models.GeneralModels.BaseRequstModules;
using System;

namespace App.Core.Models.SystemBase.Roles.DTO
{

    public class SystemRoleAddOrUpdateDTO 
    {
        public Guid systemRoleToken { get; set; }
        public string systemRoleName { get; set; }
        public string systemRoleDescription { get; set; }
        public EnumUserType systemRoleUserType { get; set; }
        public bool systemRoleCanUseDefault { get; set; }
    }
}