using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;

namespace App.Core.Interfaces.SystemBase.MedicalHistories
{
    public interface IMedicalHistoriesValid : ITransientService
    {
        BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        BaseValid ValidGetAll(BaseSearchDto inputModel);

        BaseValid ValidAddOrUpdate(MedicalHistoryAddOrUpdateDTO inputModel, bool isUpdate);

        BaseValid ValidDelete(BaseDeleteDto inputModel);

        BaseValid ValidMedicalHistoryToken(Guid medicalHistoryToken);
    }
}