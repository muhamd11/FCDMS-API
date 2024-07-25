using App.Core.Interfaces.SystemBase._01._2_SystemRoleFincations;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;

namespace Api.Controllers.SystemBase._01._2_SystemRoleFunctions.Services
{
    public class SystemRoleFunctionsClient : ISystemRoleFunctionsClientService
    {
        private readonly ISystemRoleFunctionsBaseService _systemRoleFunctionsBaseService;

        public SystemRoleFunctionsClient(ISystemRoleFunctionsBaseService systemRoleFunctionsBaseService)
        {
            _systemRoleFunctionsBaseService = systemRoleFunctionsBaseService;
        }

        public List<SystemRoleFunction> GetSystemRoleFunctions()
        {
            List<SystemRoleFunction> systemRoleFunctions = new List<SystemRoleFunction>();
            //AdditionsModules


            //PlacesModules
            //systemRoleFunctions.AddRange(GetPrivilageModuleBranches());
            //systemRoleFunctions.AddRange(GetPrivilageModuleStores());

            return systemRoleFunctions;
        }

        #region AdditionsModules


        #endregion AdditionsModules

        #region PlacesModules

        //private IEnumerable<SystemRoleFunction> GetPrivilageModuleBranches()
        //{
        //    List<SystemRoleFunction> systemRoleFunctions = [_systemRoleFunctionsBaseService.GetFunctionView(nameof(Branch))];
        //    return systemRoleFunctions;
        //}

        //private IEnumerable<SystemRoleFunction> GetPrivilageModuleStores()
        //{
        //    List<SystemRoleFunction> systemRoleFunctions = [_systemRoleFunctionsBaseService.GetFunctionView(nameof(Store))];
        //    return systemRoleFunctions;
        //}

        #endregion PlacesModules
    }
}