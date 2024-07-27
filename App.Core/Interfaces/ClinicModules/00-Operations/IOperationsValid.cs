using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.ClinicModules.OperationsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;

namespace App.Core.Interfaces.SystemBase.Operations
{
    public interface IOperationsValid : ITransientService
    {
        BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        BaseValid ValidGetAll(BaseSearchDto inputModel);

        BaseValid ValidAddOrUpdate(OperationAddOrUpdateDTO inputModel, bool isUpdate);

        BaseValid ValidDelete(BaseDeleteDto inputModel);

        BaseValid ValidOperationToken(Guid systemRoleToken);
    }
}