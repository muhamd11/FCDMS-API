using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;

namespace App.Core.Interfaces.UsersModule.UserAuthentications.UsersSignUp
{
    public interface IUsersSignUpValid : ITransientService
    {
        BaseValid IsValidSignUp(UserSignUpDto inputModel);
    }
}