using App.Core.Models.Users;

namespace App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel
{
    public class UserLoginInfo
    {
        public string userAuthorizeToken { get; set; }
        public UserInfoDetails userInfoDetails { get; set; }
    }
}