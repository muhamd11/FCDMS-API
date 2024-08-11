using App.Core.Consts.SystemBase;
using App.Core.Interfaces.SystemBase._01._2_SystemRoleFincations;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Resources.SystemBase.SystemRoleFunctions;

namespace Api.Controllers.SystemBase._01._2_SystemRoleFunctions.Services
{
    public class SystemRoleFunctionsBaseService : ISystemRoleFunctionsBaseService
    {
        public List<SystemRoleFunction> GetFunctionBasic(string moduleId)
        {
            List<SystemRoleFunction> systemRoleFincations =
            [
                GetFunctionView(moduleId),
                GetFunctionAdd(moduleId),
                GetFunctionUpdate(moduleId),
                GetFunctionDelete(moduleId),
                GetFunctionFinalDelete(moduleId),
            ];

            return systemRoleFincations;
        }

        //Base Functions
        //TODO: Add Res File For Custom Function name
        public SystemRoleFunction GetFunctionView(string moduleId) => GetFunction(moduleId, EnumFunctionsType.view, GeneralFunctionText.view);

        public SystemRoleFunction GetFunctionAdd(string moduleId) => GetFunction(moduleId, EnumFunctionsType.add, GeneralFunctionText.add);

        public SystemRoleFunction GetFunctionUpdate(string moduleId) => GetFunction(moduleId, EnumFunctionsType.update, GeneralFunctionText.update);

        public SystemRoleFunction GetFunctionDelete(string moduleId) => GetFunction(moduleId, EnumFunctionsType.delete, GeneralFunctionText.delete);

        public SystemRoleFunction GetFunctionFinalDelete(string moduleId) => GetFunction(moduleId, EnumFunctionsType.finalDelete, GeneralFunctionText.finalDelete);

        public SystemRoleFunction GetFunctionCustomize(string moduleId, string functionText, string customizeFunctionId) => GetFunction(moduleId, EnumFunctionsType.customize, functionText, customizeFunctionId);

        private SystemRoleFunction GetFunction(string moduleId, EnumFunctionsType enumFuncationsType, string functionText, string? customizeFuncationId = "") => new SystemRoleFunction()
        {
            functionsType = enumFuncationsType,
            functionText = functionText,
            customizeFunctionId = customizeFuncationId,
            moduleId = moduleId,
            functionId = customizeFuncationId == "" ? $"{moduleId}_{enumFuncationsType}" : $"{moduleId}_{enumFuncationsType}_{customizeFuncationId}",
            isHavePrivilege = false
        };
    }
}