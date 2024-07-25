using App.Core.Interfaces.SystemBase._01._2_SystemRoleFincations;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;

namespace Api.Controllers.SystemBase._01._2_SystemRoleFunctions.Services
{
    public class SystemRoleFunctionsMangerService : ISystemRoleFunctionsMangerService
    {
        private readonly ISystemRoleFunctionsBaseService _systemRoleFunctionsBaseService;

        public SystemRoleFunctionsMangerService(ISystemRoleFunctionsBaseService systemRoleFunctionsBaseService)
        {
            _systemRoleFunctionsBaseService = systemRoleFunctionsBaseService;
        }

        public List<SystemRoleFunction> GetSystemRoleFunctions()
        {
            List<SystemRoleFunction> systemRoleFincations = new List<SystemRoleFunction>();
            //AdditionsModules

            //PlacesModules
            //systemRoleFincations.AddRange(GetPrivilegeModuleBranches());
            //systemRoleFincations.AddRange(GetPrivilegeModuleStores());

            return systemRoleFincations;
        }



        #region PlacesModules

        //private IEnumerable<SystemRoleFunction> GetPrivilegeModuleBranches() =>
        //    _systemRoleFunctionsBaseService.GetFunctionBasic(nameof(Branch));

        //private IEnumerable<SystemRoleFunction> GetPrivilegeModuleStores() =>
        //    _systemRoleFunctionsBaseService.GetFunctionBasic(nameof(Store));

        #endregion PlacesModules
    }
}