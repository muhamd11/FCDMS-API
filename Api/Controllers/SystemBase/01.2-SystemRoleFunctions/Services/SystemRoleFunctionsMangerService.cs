using App.Core.Interfaces.SystemBase._01._2_SystemRoleFincations;
using App.Core.Models.ClinicModules.MedicalHistoriesModules;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.VisitsModules;
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
            List<SystemRoleFunction> systemRoleFuncations = new List<SystemRoleFunction>();

            #region ClinicModules

            systemRoleFuncations.AddRange(GetPrivilageModuleOperations());
            systemRoleFuncations.AddRange(GetPrivilageModuleNutritionalImprovement());
            systemRoleFuncations.AddRange(GetPrivilageModuleVisit());
            systemRoleFuncations.AddRange(GetPrivilageModuleMedicalHistory());

            #endregion ClinicModules

            return systemRoleFuncations;
        }

        #region ClinicModules

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleOperations() => _systemRoleFunctionsBaseService.GetFunctionBasic(nameof(Operation));

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleNutritionalImprovement() => _systemRoleFunctionsBaseService.GetFunctionBasic(nameof(NutritionalImprovement));

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleVisit() => _systemRoleFunctionsBaseService.GetFunctionBasic(nameof(Visit));

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleMedicalHistory() => _systemRoleFunctionsBaseService.GetFunctionBasic(nameof(MedicalHistory));

        #endregion ClinicModules
    }
}