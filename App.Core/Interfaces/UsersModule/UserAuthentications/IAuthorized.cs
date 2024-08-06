using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;

namespace App.Core.Interfaces.UsersModule.UserAuthentications
{
    public interface IAuthorized: ITransientService
    {
        BaseValid IsAuthorizedUser(string functionId);
    }
}