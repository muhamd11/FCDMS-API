using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.SystemBase.Roles.DTO;

namespace App.Core.Interfaces.SystemBase.SystemRoles
{
    public interface ISystemRolesValid : ITransientService
    {
        BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        BaseValid ValidGetAll(BaseSearchDto inputModel);

        BaseValid ValidAddOrUpdate(SystemRoleAddOrUpdateDTO inputModel, bool isUpdate);

        BaseValid ValidDelete(BaseDeleteDto inputModel);

        BaseValid ValidSystemRoleToken(Guid systemRoleToken);
    }
}