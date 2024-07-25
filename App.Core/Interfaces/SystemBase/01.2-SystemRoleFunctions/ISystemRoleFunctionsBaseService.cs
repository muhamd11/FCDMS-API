using App.Core.Consts.SystemBase;
using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using System.Collections.Generic;

namespace App.Core.Interfaces.SystemBase._01._2_SystemRoleFincations
{
    public interface ISystemRoleFunctionsBaseService : ISingletonService
    {
        public List<SystemRoleFunction> GetFunctionBasic(string moduleId);

        //Base Functions
        public SystemRoleFunction GetFunctionView(string moduleId);

        public SystemRoleFunction GetFunctionAdd(string moduleId);

        public SystemRoleFunction GetFunctionUpdate(string moduleId);

        public SystemRoleFunction GetFunctionDelete(string moduleId);

        public SystemRoleFunction GetFunctionFinalDelete(string moduleId);

        public SystemRoleFunction GetFunctionCustomize(string moduleId, EnumFunctionsType customize);
    }
}