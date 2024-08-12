using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;
using App.Core.Models.SystemBase._02_LogActions.DTO;
using App.Core.Models.SystemBase.LogActions.DTO;
using App.Core.Models.SystemBase.LogActions.ViewModel;

namespace App.Core.Interfaces.SystemBase.LogActions
{
    public interface ILogActionsServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<LogActionInfo>> GetAllAsync(LogActionSearchDto inputModel);

        Task<LogActionInfoDetails> GetDetails(LogActionGetDetails inputModel);
    }
}