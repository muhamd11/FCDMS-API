using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.ClinicModules.OperationsModules.DTO;
using App.Core.Models.ClinicModules.VisitsModules;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;

namespace App.Core.Interfaces.SystemBase.Operations
{
    public interface IOperationsServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<OperationInfo>> GetAllAsync(OperationSearchDTO inputModel);

        Task<OperationInfoDetails> GetDetails(OperationGetDetailsDTO inputModel);

        Task<BaseActionDone<OperationInfo>> AddOrUpdate(OperationAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<OperationInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}