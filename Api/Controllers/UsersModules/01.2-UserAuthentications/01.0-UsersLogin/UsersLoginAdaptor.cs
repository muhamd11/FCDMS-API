using Api.Controllers.UsersModule.Users;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications._01._0_UsersLogin
{
    public class UsersLoginAdaptor
    {
        public static Expression<Func<User, UserLoginInfo>> SelectExpressionUserLoginInfo()
        {
            return user => new UserLoginInfo
            {
                userInfoDetails = UsersAdaptor.SelectExpressionUserInfoDetails(user)
            };
        }

        public static UserLoginInfo SelectExpressionUserLoginInfo(User user, string userAuthorizeToken)
        {
            if (user == null)
                return null;

            return new UserLoginInfo
            {
                userAuthorizeToken = userAuthorizeToken,
                userInfoDetails = UsersAdaptor.SelectExpressionUserInfoDetails(user)
            };
        }
    }
}