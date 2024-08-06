using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.SystemBase.LogActions.DTO;

namespace App.Core.Interfaces.SystemBase.LogActions
{
    public interface ILogActionsValid : ITransientService
    {
        BaseValid ValidGetAll(LogActionSearchDto inputModel);

        BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        BaseValid ValidLogActionToken(Guid logActionToken);
    }
}