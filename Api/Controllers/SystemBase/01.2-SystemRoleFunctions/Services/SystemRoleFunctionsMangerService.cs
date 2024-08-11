using App.Core.Consts.SystemBase;
using App.Core.Interfaces.SystemBase._01._2_SystemRoleFincations;
using App.Core.Models.ClinicModules.MedicalHistoriesModules;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.VisitsModules;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Models.SystemBase.LogActions;
using App.Core.Models.SystemBase.Roles;
using App.Core.Models.Users;

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

            #region SystemBase

            systemRoleFuncations.AddRange(GetPrivilageModuleSystemRole());
            systemRoleFuncations.AddRange(GetPrivilageModuleSystemRoleFunction());
            systemRoleFuncations.AddRange(GetPrivilageModuleLogAction());

            #endregion SystemBase

            #region UserModules

            systemRoleFuncations.AddRange(GetPrivilageModuleUser());

            #endregion UserModules

            return systemRoleFuncations;
        }

        #region ClinicModules

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleOperations()
        {
            string moduleId = nameof(Operation);
            List<SystemRoleFunction> systemRoleFunctions =
            [
                .. _systemRoleFunctionsBaseService.GetFunctionBasic(moduleId),
                _systemRoleFunctionsBaseService.GetFunctionCustomize(moduleId,"تغير حالة التفعيل", EnumBaseCustomFunctions.changeActivationType.ToString()),
            ];
            return systemRoleFunctions;
        }

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleNutritionalImprovement()
        {
            string moduleId = nameof(NutritionalImprovement);
            List<SystemRoleFunction> systemRoleFunctions =
            [
                .. _systemRoleFunctionsBaseService.GetFunctionBasic(moduleId),
                _systemRoleFunctionsBaseService.GetFunctionCustomize(moduleId,"تغير حالة التفعيل", EnumBaseCustomFunctions.changeActivationType.ToString()),
            ];
            return systemRoleFunctions;
        }

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleVisit()
        {
            string moduleId = nameof(Visit);
            List<SystemRoleFunction> systemRoleFunctions =
            [
                .. _systemRoleFunctionsBaseService.GetFunctionBasic(moduleId),
                _systemRoleFunctionsBaseService.GetFunctionCustomize(moduleId,"تغير حالة التفعيل", EnumBaseCustomFunctions.changeActivationType.ToString()),
            ];
            return systemRoleFunctions;
        }

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleMedicalHistory()
        {
            string moduleId = nameof(MedicalHistory);
            List<SystemRoleFunction> systemRoleFunctions =
            [
                .. _systemRoleFunctionsBaseService.GetFunctionBasic(moduleId),
                _systemRoleFunctionsBaseService.GetFunctionCustomize(moduleId,"تغير حالة التفعيل", EnumBaseCustomFunctions.changeActivationType.ToString()),
            ];
            return systemRoleFunctions;
        }

        #endregion ClinicModules

        #region SystemBase

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleSystemRole()
        {
            string moduleId = nameof(SystemRole);
            List<SystemRoleFunction> systemRoleFunctions =
            [
                .. _systemRoleFunctionsBaseService.GetFunctionBasic(moduleId),
                _systemRoleFunctionsBaseService.GetFunctionCustomize(moduleId,"تغير حالة التفعيل", EnumBaseCustomFunctions.changeActivationType.ToString()),
            ];
            return systemRoleFunctions;
        }

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleSystemRoleFunction() => _systemRoleFunctionsBaseService.GetFunctionBasic(nameof(SystemRoleFunction));

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleLogAction() => _systemRoleFunctionsBaseService.GetFunctionBasic(nameof(LogAction));

        #endregion SystemBase

        #region UserModules

        private IEnumerable<SystemRoleFunction> GetPrivilageModuleUser()
        {
            string moduleId = nameof(User);
            List<SystemRoleFunction> systemRoleFunctions =
            [
                .. _systemRoleFunctionsBaseService.GetFunctionBasic(moduleId),
                _systemRoleFunctionsBaseService.GetFunctionCustomize(moduleId,"تغير حالة التفعيل", EnumBaseCustomFunctions.changeActivationType.ToString()),
            ];
            return systemRoleFunctions;
         }

        #endregion UserModules
    }
}