using Api.Controllers.UsersModules._01._2_UserAuthentications._01._0_UsersLogin;
using Api.Controllers.UsersModules._01._2_UserAuthentications._01._0_UsersSignUp;
using App.Core;
using App.Core.Consts.Users;
using App.Core.Helper;
using App.Core.Helper.Json;
using App.Core.Helper.Validations;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Interfaces.UsersModule.Users;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.ViewModel;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications
{
    public class UserAuthServices : IUserAuthServices
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersServices _usersServices;
        private readonly IMapper _mapper;

        #endregion Members

        #region Constructor

        public UserAuthServices(IUnitOfWork unitOfWork, IUsersServices usersServices, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _usersServices = usersServices;
            _mapper = mapper;
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

        public async Task<UserSignUpInfo> Signup(UserSignUpDto inputModel)
        {
            var user = _mapper.Map<User>(inputModel);
            user.userTypeToken = EnumUserType.Patient;
            user.userPassword = MethodsClass.Encrypt_Base64(inputModel.userPassword);
            ClearInvalidUserFields(user);

            user = await _unitOfWork.Users.AddAsync(user);

            await _unitOfWork.CommitAsync();

            return UsersSignUpAdaptor.SelectExpressionUserSignUpInfo(user);
        }

        private static void ClearInvalidUserFields(User userOnly)
        {
            if (!ValidationClass.IsValidString(userOnly.userEmail))
                userOnly.userEmail = null;
            if (!ValidationClass.IsValidString(userOnly.userLoginName))
                userOnly.userLoginName = null;
            if (!ValidationClass.IsValidString(userOnly.userPhone))
                userOnly.userPhone = null;
            if (!ValidationClass.IsValidString(userOnly.fullCode))
                userOnly.fullCode = null;
        }

        private string GenerateUserAuthorizeToken(User user)
        {
            UserAuthorize userAuthorize = new()
            {
                userToken = user.userToken,
                userType = user.userTypeToken,
                systemRoleToken = user.systemRoleToken == null ? Guid.Empty : (Guid)user.systemRoleToken
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