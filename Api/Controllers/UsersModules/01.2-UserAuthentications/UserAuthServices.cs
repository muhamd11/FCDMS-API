using Api.Controllers.UsersModules._01._2_UserAuthentications._01._0_UsersLogin;
using App.Core;
using App.Core.Helper;
using App.Core.Helper.Json;
using App.Core.Interfaces.UsersModule.UsersAuthentications;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications
{
    public class UserAuthServices : IUserAuthServices
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UserAuthServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region Methods

        public async Task<UserLoginInfo> Login(UserLoginDto inputModel)
        {
            inputModel.userPassword = MethodsClass.Encrypt_Base64(inputModel.userPassword);

            var criteria = GenerateCriteria(inputModel);
            var includes = GenerateIncludes();

            var user = await _unitOfWork.Users.FirstOrDefaultAsync(criteria, includes);

            var userAuthorizeToken = GenerateUserAuthorizeToken(user);

            return UsersLoginAdaptor.SelectExpressionUserLoginInfo(user, userAuthorizeToken);
        }

        private string GenerateUserAuthorizeToken(User user)
        {
            UserAuthorize userAuthorize = new()
            {
                userToken = user.userToken,
                userType = user.userType,
                systemRoleToken = user.systemRoleToken
            };
            return JsonConversion.SerializeUserAuthorizeToken(userAuthorize);
        }

        private static List<Expression<Func<User, object>>> GenerateIncludes()
        {
            List<Expression<Func<User, object>>> includes = [];

            includes.Add(x => x.roleData);
            includes.Add(x => x.userProfileData);
            return includes;
        }

        private static Expression<Func<User, bool>> GenerateCriteria(UserLoginDto inputModel)
        {
            Expression<Func<User, bool>> criteria = x => x.userPassword == inputModel.userPassword &&
            (x.userPhone == inputModel.userLoginText || x.userEmail == inputModel.userLoginText || x.userLoginName == inputModel.userLoginText);
            return criteria;
        }

        #endregion Methods
    }
}