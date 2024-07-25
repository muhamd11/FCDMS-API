using App.Core.Models.GeneralModels.BaseRequstModules;
using System;
using System.Collections.Generic;

namespace App.Core.Models.SystemBase._01._2_SystemRoleFunctions.DTO
{
    public class SystemRoleFunctionDto : GeneralOperation
    {
        public SystemRoleFunctionDto()
        {
            systemRoleFunctions = new HashSet<SystemRoleFunction>();
        }

        public Guid systemRoleToken { get; set; }
        public ICollection<SystemRoleFunction> systemRoleFunctions { get; set; }
    }
}