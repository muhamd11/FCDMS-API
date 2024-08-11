using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.GeneralModels.BaseRequstModules;

namespace App.Core.Interfaces.SystemBase.NutritionalImprovements
{
    public interface INutritionalImprovementsValid : ITransientService
    {
        BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        BaseValid ValidGetAll(BaseSearchDto inputModel);

        BaseValid ValidAddOrUpdate(NutritionalImprovementAddOrUpdateDTO inputModel, bool isUpdate);
        BaseValid isValidChangeActivationTypeNutritionalImprovement(BaseChangeActivationDto inputModel);

        BaseValid ValidDelete(BaseDeleteDto inputModel);

        BaseValid ValidNutritionalImprovementToken(Guid nutritionalImprovementToken);
    }
}