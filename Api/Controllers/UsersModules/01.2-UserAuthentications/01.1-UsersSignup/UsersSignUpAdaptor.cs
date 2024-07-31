using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.ViewModel;


namespace Api.Controllers.UsersModules._01._2_UserAuthentications._01._0_UsersSignUp
{
    public class UsersSignUpAdaptor
    {
        public static UserSignUpInfo SelectExpressionUserSignUpInfo(UserInfo user)
        {
            if (user == null)
                return null;

            return new UserSignUpInfo
            {
                userInfoData = user
            };
        }
    }
}