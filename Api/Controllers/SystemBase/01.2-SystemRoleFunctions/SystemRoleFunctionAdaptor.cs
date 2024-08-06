using Api.Controllers.SystemBase.BaseEntitys;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase._01._2_SystemRoleFunctions
{
    public class SystemRoleFunctionAdaptor
    {
        public static Expression<Func<SystemRoleFunction, SystemRoleFunctionInfo>> SelectExpressionSystemRoleFunctionInfo()
        {
            return systemRoleFunction => new SystemRoleFunctionInfo
            {
                systemRoleToken = systemRoleFunction.systemRoleToken,
                functionsType = systemRoleFunction.functionsType,
                functionId = systemRoleFunction.functionId,
                moduleId = systemRoleFunction.moduleId,
                isHavePrivilege = systemRoleFunction.isHavePrivilege,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRoleFunction).isDeleted,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRoleFunction).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRoleFunction).createdDateTime
            };
        }

        public static SystemRoleFunctionInfo SelectExpressionSystemRoleFunctionInfo(SystemRoleFunction systemRoleFunction)
        {
            if (systemRoleFunction == null)
                return null;

            return new SystemRoleFunctionInfo
            {
                systemRoleToken = systemRoleFunction.systemRoleToken,
                functionsType = systemRoleFunction.functionsType,
                functionId = systemRoleFunction.functionId,
                moduleId = systemRoleFunction.moduleId,
                isHavePrivilege = systemRoleFunction.isHavePrivilege,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRoleFunction).isDeleted,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRoleFunction).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRoleFunction).createdDateTime
            };
        }
    }
}