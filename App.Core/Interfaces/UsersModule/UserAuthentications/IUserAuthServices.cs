using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;

namespace App.Core.Interfaces.UsersModule.UsersAuthentications
{
    public interface IUserAuthServices : ITransientService
    {
        Task<UserLoginInfo> Login(UserLoginDto inputModel);
    }
}