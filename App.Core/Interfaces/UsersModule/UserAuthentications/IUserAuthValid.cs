using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;
using App.Core.Models.GeneralModels.BaseRequestHeaderModules;

namespace App.Core.Interfaces.UsersModule.UserAuthentications
{
    public interface IUserAuthValid : ITransientService
    {
        BaseValid IsAuthenticated(BaseRequestHeaders inputModel);
    }
}