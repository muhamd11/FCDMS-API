using App.Core.Consts.SystemBase;
using App.Core.Interfaces.SystemBase._01._2_SystemRoleFincations;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;

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
        public SystemRoleFunction GetFunctionView(string moduleId) => GetFunction(moduleId, EnumFunctionsType.view);

        public SystemRoleFunction GetFunctionAdd(string moduleId) => GetFunction(moduleId, EnumFunctionsType.add);

        public SystemRoleFunction GetFunctionUpdate(string moduleId) => GetFunction(moduleId, EnumFunctionsType.update);

        public SystemRoleFunction GetFunctionDelete(string moduleId) => GetFunction(moduleId, EnumFunctionsType.delete);

        public SystemRoleFunction GetFunctionFinalDelete(string moduleId) => GetFunction(moduleId, EnumFunctionsType.finalDelete);

        public SystemRoleFunction GetFunctionCustomize(string moduleId, EnumFunctionsType customize) => GetFunction(moduleId, customize);

        private SystemRoleFunction GetFunction(string moduleId, EnumFunctionsType enumFuncationsType)
        {
            return new SystemRoleFunction()
            {
                functionsType = enumFuncationsType,
                moduleId = moduleId,
                functionId = $"{moduleId}_{enumFuncationsType}",
                isHavePrivilege = false
            };
        }
    }
}