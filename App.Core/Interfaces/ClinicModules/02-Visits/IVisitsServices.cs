using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.ClinicModules.VisitsModules;
using App.Core.Models.ClinicModules.VisitsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.GeneralModels.BaseRequstModules;

namespace App.Core.Interfaces.SystemBase.Visits
{
    public interface IVisitsServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<VisitInfo>> GetAllAsync(VisitSearchDTO inputModel);

        Task<VisitInfoDetails> GetDetails(VisitGetDetailsDTO inputModel);

        Task<BaseActionDone<VisitInfo>> AddOrUpdate(VisitAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<VisitInfo>> ChangeVisitActivationType(BaseChangeActivationDto inputModel);

        Task<BaseActionDone<VisitInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}