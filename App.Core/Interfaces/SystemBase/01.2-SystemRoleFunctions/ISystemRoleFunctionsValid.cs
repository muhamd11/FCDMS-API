using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.DTO;

namespace Api.Controllers.SystemBase.LogActions.Interfaces
{
    public interface ISystemRoleFunctionsValid : ITransientService
    {
        public BaseValid ValidGetDetails(Guid systemRoleToken);

        public BaseValid ValidUpdatePrivilege(SystemRoleFunctionDto inputModel);
    }
}