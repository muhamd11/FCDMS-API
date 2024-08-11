using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.DTO;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.ViewModel;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.GeneralModels.BaseRequstModules;

namespace App.Core.Interfaces.SystemBase.NutritionalImprovements
{
    public interface INutritionalImprovementsServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<NutritionalImprovementInfo>> GetAllAsync(NutritionalImprovementSearchDTO inputModel);

        Task<NutritionalImprovementInfoDetails> GetDetails(NutritionalImprovementGetDetailsDTO inputModel);

        Task<BaseActionDone<NutritionalImprovementInfo>> AddOrUpdate(NutritionalImprovementAddOrUpdateDTO inputModel, bool isUpdate);
        Task<BaseActionDone<NutritionalImprovementInfo>> ChangeNutritionalImprovementActivationType(BaseChangeActivationDto inputModel);
        Task<BaseActionDone<NutritionalImprovementInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}