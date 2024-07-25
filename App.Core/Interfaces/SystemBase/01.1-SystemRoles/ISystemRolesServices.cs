using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.SystemBase.Roles.DTO;
using App.Core.Models.SystemBase.Roles.ViewModel;

namespace App.Core.Interfaces.SystemBase.SystemRoles
{
    public interface ISystemRolesServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<SystemRoleInfo>> GetAllAsync(SystemRoleSearchDto inputModel);

        Task<SystemRoleInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<SystemRoleInfo>> AddOrUpdate(SystemRoleAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<SystemRoleInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}