using Api.Controllers.UsersModules.Users.Interfaces;
using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Consts.Users;
using App.Core.Helper.Validations;
using App.Core.Interfaces.GeneralInterfaces;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.General.LocalModels;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;
using App.Core.Resources.General;
using App.Core.Resources.UsersModules.User;
using AutoMapper;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications
{
    public class UserAuthenticationValid : IUserAuthenticationValid
    {
        private readonly IMapper _mapper;
        private readonly IUsersValid _usersValid;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHeaderRequest _headerRequest;

        public UserAuthenticationValid(IUsersValid usersValid, IMapper mapper, IUnitOfWork unitOfWork, IHeaderRequest headerRequest)
        {
            _mapper = mapper;
            _usersValid = usersValid;
            _unitOfWork = unitOfWork;
            _headerRequest = headerRequest;
        }

        public BaseValid IsValidLogin(UserLoginDto inputModel)
        {
            if (inputModel is not null)
            {
                #region userLoginText *

                if (!ValidationClass.IsValidString(inputModel.userLoginText))
                    return BaseValid.createBaseValid(UsersMessagesAr.errorInvalidLoginData, EnumStatus.error);

                #endregion userLoginText *

                #region userPasswordText *

                if (!ValidationClass.IsValidString(inputModel.userPassword))
                    return BaseValid.createBaseValid(UsersMessagesAr.errorUserPasswordIsRequired, EnumStatus.error);

                #endregion userPasswordText *

                return BaseValid.createBaseValid(UsersMessagesAr.loginSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid IsValidSignUp(UserSignUpDto inputModel)
        {
            if (inputModel is not null)
            {
                var userAddOrUpdateDTO = _mapper.Map<UserAddOrUpdateDTO>(inputModel);
                userAddOrUpdateDTO.userTypeToken = EnumUserType.Patient;

                #region userPassword *

                if (!ValidationClass.IsValidString(inputModel.userPassword))
                    return BaseValid.createBaseValid(GeneralMessagesAr.errorPasswordRequired, EnumStatus.error);

                #endregion userPassword *

                #region ValidUserData*

                var isValidUserData = _usersValid.ValidUserData(userAddOrUpdateDTO);
                if (isValidUserData.Status != EnumStatus.success)
                    return isValidUserData;

                #endregion ValidUserData*

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid IsValidUserForOtp(CheckUserForOtpDTO inputModel)
        {
            if (inputModel is not null)
            {
                #region userPhoneNumberOrEmail *

                if (!ValidationClass.IsValidString(inputModel.userPhoneNumberOrEmail))
                    return BaseValid.createBaseValid(GeneralMessagesAr.errorPhoneNumberOrEmailRequired, EnumStatus.error);

                #endregion userPhoneNumberOrEmail *

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid IsValidOtp(VerifyOtpDTO inputModel)
        {
            if (inputModel is not null)
            {
                #region ValidOtp *

                var OtpRecord = _unitOfWork.OtpRecords.FirstOrDefault(x => x.userOtp == inputModel.userOtp);

                if (OtpRecord == null)
                    return BaseValid.createBaseValid(UsersMessagesAr.errorInvalidUserOtp, EnumStatus.error);

                if (DateTime.UtcNow > OtpRecord.expireDate)
                    return BaseValid.createBaseValid(UsersMessagesAr.errorOtpExpired, EnumStatus.error);

                #endregion ValidOtp *

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid IsValidChangePassword(ChangePasswordDTO inputModel)
        {
            if (inputModel is not null)
            {
                #region userAuthorizeToken *

                if (!ValidationClass.IsValidString(inputModel.userAuthorizeToken))
                    return BaseValid.createBaseValid(UsersMessagesAr.errorUserAuthorizeTokenNotFound, EnumStatus.error);

                #endregion userAuthorizeToken *

                #region newUserPassword *

                if (!ValidationClass.IsValidString(inputModel.newUserPassword))
                    return BaseValid.createBaseValid(UsersMessagesAr.errorUserPasswordIsRequired, EnumStatus.error);

                #endregion newUserPassword *

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }
    }
}