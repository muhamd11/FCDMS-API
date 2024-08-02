using App.Core.Interfaces.SystemBase._01._2_SystemRoleFincations;
using App.Core.Models.ClinicModules.MedicalHistoriesModules;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.VisitsModules;
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

            #region ClinicModules

            systemRoleFunctions.AddRange(GetPrivilageModuleOperations());
            systemRoleFunctions.AddRange(GetPrivilageModuleNutritionalImprovement());
            systemRoleFunctions.AddRange(GetPrivilageModuleVisit());
            systemRoleFunctions.AddRange(GetPrivilageModuleMedicalHistory());

            #endregion ClinicModules


            return systemRoleFunctions;
        }

        #region ClinicModules

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleOperations()
        {
            List<SystemRoleFunction> systemRoleFunctions = [_systemRoleFunctionsBaseService.GetFunctionView(nameof(Operation))];
            return systemRoleFunctions;
        }

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleNutritionalImprovement()
        {
            List<SystemRoleFunction> systemRoleFunctions = [_systemRoleFunctionsBaseService.GetFunctionView(nameof(NutritionalImprovement))];
            return systemRoleFunctions;
        }

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleVisit()
        {
            List<SystemRoleFunction> systemRoleFunctions = [_systemRoleFunctionsBaseService.GetFunctionView(nameof(Visit))];
            return systemRoleFunctions;
        }

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleMedicalHistory()
        {
            List<SystemRoleFunction> systemRoleFunctions = [_systemRoleFunctionsBaseService.GetFunctionView(nameof(MedicalHistory))];
            return systemRoleFunctions;
        }

        #endregion ClinicModules
    }
}