using App.Core.Consts.SystemBase;
using App.Core.Models.SystemBase.BaseClass;

namespace App.Core.Models.SystemBase._01._2_SystemRoleFunctions.ViewModel
{
    public class SystemRoleFunctionInfo 
    {
        public Guid systemRoleToken { get; set; }
        public EnumFunctionsType functionsType { get; set; }
        public string functionText { get; set; }
        public string moduleId { get; set; }
        public string functionId { get; set; }
        public bool isHavePrivilege { get; set; }
    }
}