using Api.Controllers.UsersModule.Users;
using App.Core;
using App.Core.Consts.Users;
using App.Core.Helper;
using App.Core.Helper.Json;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Interfaces.UsersModule.Users;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications
{
    public class UserAuthenticationServices : IUserAuthenticationServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersServices _usersServices;

        #endregion Members

        #region Constructor

        public UserAuthenticationServices(IUnitOfWork unitOfWork, IUsersServices usersServices, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _usersServices = usersServices;
        }

        #endregion Constructor

        #region Methods

        public async Task<UserLoginInfo> Login(UserLoginDto inputModel)
        {
            inputModel.userPassword = MethodsClass.Encrypt_Base64(inputModel.userPassword);

            var criteria = GenerateLoginCriteria(inputModel);

            var select = UsersAdaptor.SelectExpressionUserInfoDetails();

            var userInfoDetails = await _unitOfWork.Users.FirstOrDefaultAsync(criteria, select);

            var userAuthorizeToken = GenerateUserAuthorizeToken(userInfoDetails);

            return new() { userAuthorizeToken = userAuthorizeToken, userInfoDetails = userInfoDetails };
        }

        public async Task<UserInfo> Signup(UserSignUpDto inputModel)
        {
            var userData = await _usersServices.AddFromSginUp(inputModel);
            return userData.Data;
        }

        private string GenerateUserAuthorizeToken(UserInfoDetails user)
        {
            var systemRoleToken = user.roleData?.systemRoleToken;
            UserAuthorize userAuthorize = new()
            {
                userToken = (Guid)user.userToken!,
                userType = (EnumUserType)user.userTypeToken!,
                systemRoleToken = systemRoleToken.HasValue == true ? (Guid)systemRoleToken : Guid.Empty,
            };
            return JsonConversion.SerializeUserAuthorizeToken(userAuthorize);
        }

        private List<Expression<Func<User, bool>>> GenerateLoginCriteria(UserLoginDto inputModel)
        {
            List<Expression<Func<User, bool>>> criteria =
            [
                x => x.userPhone == inputModel.userLoginText || x.userEmail == inputModel.userLoginText || x.userLoginName == inputModel.userLoginText,
                x => x.userPassword == inputModel.userPassword,
            ];
            return criteria;
        }

        #endregion Methods
    }
}