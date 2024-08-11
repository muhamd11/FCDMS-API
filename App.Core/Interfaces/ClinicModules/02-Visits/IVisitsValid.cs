using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.ClinicModules.VisitsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.GeneralModels.BaseRequstModules;

namespace App.Core.Interfaces.SystemBase.Visits
{
    public interface IVisitsValid : ITransientService
    {
        BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        BaseValid ValidGetAll(BaseSearchDto inputModel);

        BaseValid ValidAddOrUpdate(VisitAddOrUpdateDTO inputModel, bool isUpdate);

        BaseValid isValidChangeActivationTypeVisit(BaseChangeActivationDto inputModel);

        BaseValid ValidDelete(BaseDeleteDto inputModel);

        BaseValid ValidVisitToken(Guid visitToken);
    }
}