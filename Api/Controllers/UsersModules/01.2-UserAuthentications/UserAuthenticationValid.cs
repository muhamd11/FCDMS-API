using Api.Controllers.UsersModules.Users.Interfaces;
using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Consts.Users;
using App.Core.Helper;
using App.Core.Helper.Validations;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.General.LocalModels;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;
using App.Core.Resources.General;
using App.Core.Resources.UsersModules.User;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications._01._0_UsersLogin
{
    public class UserAuthenticationValid : IUserAuthenticationValid
    {
        private readonly IMapper _mapper;
        private readonly IUsersValid _usersValid;

        public UserAuthenticationValid(IUsersValid usersValid, IMapper mapper)
        {
            _mapper = mapper;
            _usersValid = usersValid;
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


        BaseValid IUserAuthenticationValid.IsValidSginUp(UserSignUpDto inputModel)
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
                #endregion

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }
    }
}