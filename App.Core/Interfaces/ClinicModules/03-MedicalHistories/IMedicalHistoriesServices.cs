using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.DTO;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.ViewModel;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.GeneralModels.BaseRequstModules;

namespace App.Core.Interfaces.SystemBase.MedicalHistories
{
    public interface IMedicalHistoriesServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<MedicalHistoryInfo>> GetAllAsync(MedicalHistorySearchDTO inputModel);

        Task<MedicalHistoryInfoDetails> GetDetails(MedicalHistoryGetDetailsDTO inputModel);

        Task<BaseActionDone<MedicalHistoryInfo>> AddOrUpdate(MedicalHistoryAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<MedicalHistoryInfo>> ChangeMedicalHistoryActivationType(BaseChangeActivationDto inputModel);

        Task<BaseActionDone<MedicalHistoryInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}