using App.Core.Models.GeneralModels.BaseRequestHeaderModules;

namespace App.Core.Models.SystemBase._01._2_SystemRoleFunctions.DTO
{
    public class SystemRoleFunctionDto : BaseRequestHeaders
    {
        public SystemRoleFunctionDto()
        {
            systemRoleFunctions = new HashSet<SystemRoleFunction>();
        }

        public Guid systemRoleToken { get; set; }
        public ICollection<SystemRoleFunction> systemRoleFunctions { get; set; }
    }
}