using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;

namespace App.Core.Interfaces.UsersModule.UsersAuthentications.UsersLogin
{
    public interface IUsersLoginValid : ITransientService
    {
        BaseValid IsValidLogin(UserLoginDto inputModel);
    }
}