using Api.Controllers.UsersModule.Users;
using App.Core;
using App.Core.Consts.Users;
using App.Core.Helper;
using App.Core.Helper.Json;
using App.Core.Interfaces.GeneralInterfaces;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Interfaces.UsersModule.Users;
using App.Core.Models.General.LocalModels;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications;
using App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules;
using App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules.ViewModel;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications
{
    public class UserAuthenticationServices : IUserAuthenticationServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersServices _usersServices;
        private readonly IHeaderRequest _headerRequest;

        #endregion Members

        #region Constructor

        public UserAuthenticationServices(IUnitOfWork unitOfWork, IUsersServices usersServices, IMapper mapper, IHeaderRequest headerRequest)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _usersServices = usersServices;
            _headerRequest = headerRequest;
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

            if (userInfoDetails is null || userAuthorizeToken is null) return null;

            return new() { userAuthorizeToken = userAuthorizeToken, userInfoDetails = userInfoDetails };
        }

        public async Task<UserInfo> Signup(UserSignUpDto inputModel)
        {
            var userData = await _usersServices.AddFromSginUp(inputModel);
            return userData.Data;
        }

        public async Task<BaseActionDone<CheckUserForOtpInfo>> CheckUserForOtp(CheckUserForOtpDTO inputModel)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userEmail == inputModel.userPhoneNumberOrEmail || x.userPhone == inputModel.userPhoneNumberOrEmail);
            return await AddOtpRecord(user);
        }

        private async Task<BaseActionDone<CheckUserForOtpInfo>> AddOtpRecord(User user)
        {
            OtpRecord otpRecord = new();
            otpRecord.userToken = user.userToken;
            otpRecord.expireDate = DateTime.UtcNow.AddMinutes(10);
            otpRecord.userOtp = GenerateOtp();

            await _unitOfWork.OtpRecords.AddAsync(otpRecord);

            var isDone = await _unitOfWork.CommitAsync();

            return BaseActionDone<CheckUserForOtpInfo>.GenrateBaseActionDone(isDone, new CheckUserForOtpInfo() { userOtp = otpRecord.userOtp });
        }

        public async Task<VerifyOtpInfo> VerifyOtp(VerifyOtpDTO inputModel)
        {
            var select = UsersAdaptor.SelectExpressionUserInfoDetails();

            var otpRecord = await _unitOfWork.OtpRecords.FirstOrDefaultAsync(x => x.userOtp == inputModel.userOtp);

            var userInfoDetails = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userToken == otpRecord.userToken, select);

            var userAuthorizeToken = GenerateUserAuthorizeToken(userInfoDetails);

            return new() { userAuthorizeToken = userAuthorizeToken };
        }

        public async Task<BaseActionDone<ChangePasswordInfo>> ChangePassword(ChangePasswordDTO inputModel)
        {
            var userAuth = JsonConversion.DeserializeUserAuthorizeToken(inputModel.userAuthorizeToken);

            var select = UsersAdaptor.SelectExpressionUserInfoDetails();

            var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userToken == userAuth.userToken);

            if (user is null) return null;

            user.userPassword = MethodsClass.Encrypt_Base64(inputModel.newUserPassword);

            _unitOfWork.Users.Update(user);

            var isDone = await _unitOfWork.CommitAsync();

            if (isDone > 0)
                await _unitOfWork.OtpRecords.AsQueryable().Where(x => x.userToken == user.userToken).ExecuteDeleteAsync();

            var userInfoDetails = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userToken == user.userToken, select);

            return BaseActionDone<ChangePasswordInfo>.GenrateBaseActionDone(isDone, new ChangePasswordInfo() { userInfoDetails = userInfoDetails });
        }

        private string GenerateOtp()
        {
            int maxNumber = 6;
            string result;
            Random random = new Random();
            int value = random.Next(0, 999999);
            if (value.ToString().Length == maxNumber)
            {
                result = "" + value;
                return result;
            }
            else
            {
                result = "" + value;
                for (int i = result.ToString().Length; i < maxNumber; i++)
                {
                    result += "" + random.Next(0, 9);
                }
                return result;
            }
        }

        private string GenerateUserAuthorizeToken(UserInfoDetails user)
        {
            if (user is null) return null;

            var systemRoleToken = user.roleData?.systemRoleToken;
            UserAuthorize userAuthorize = new()
            {
                userToken = (Guid)user.userToken!,
                userType = (EnumUserType)user.userTypeToken!,
                systemRoleToken = systemRoleToken.HasValue ? (Guid)systemRoleToken : Guid.Empty,
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