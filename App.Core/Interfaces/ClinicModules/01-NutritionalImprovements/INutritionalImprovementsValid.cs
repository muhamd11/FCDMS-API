using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;

namespace App.Core.Interfaces.SystemBase.NutritionalImprovements
{
    public interface INutritionalImprovementsValid : ITransientService
    {
        BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        BaseValid ValidGetAll(BaseSearchDto inputModel);

        BaseValid ValidAddOrUpdate(NutritionalImprovementAddOrUpdateDTO inputModel, bool isUpdate);

        BaseValid ValidDelete(BaseDeleteDto inputModel);

        BaseValid ValidNutritionalImprovementToken(Guid systemRoleToken);
    }
}