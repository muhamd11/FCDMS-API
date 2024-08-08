
namespace App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules.DTO
{
    public class ChangePasswordDTO
    {
        public string userAuthorizeToken { get; set; }
        public string newUserPassword { get; set; }
    }
}
