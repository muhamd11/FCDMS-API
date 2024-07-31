using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.ViewModel;

namespace App.Core.Interfaces.UsersModule.UserAuthentications
{
    public interface IUserAuthServices : ITransientService
    {
        Task<UserLoginInfo> Login(UserLoginDto inputModel);
        Task<UserSignUpInfo> Signup(UserSignUpDto inputModel);
    }
}