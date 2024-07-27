using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Helper;
using App.Core.Helper.Validations;
using App.Core.Interfaces.UsersModule.UsersAuthentications.UsersLogin;
using App.Core.Models.General.LocalModels;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Resources.General;
using App.Core.Resources.UsersModules.User;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications._01._0_UsersLogin
{
    public class UsersLoginValid : IUsersLoginValid
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersLoginValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BaseValid IsValidLogin(UserLoginDto inputModel)
        {
            if (inputModel is not null)
            {
                #region userLoginText *

                if (!ValidationClass.IsValidString(inputModel.userLoginText))
                    return BaseValid.createBaseValid(UsersMessagesAr.errorInvalidLoginData, EnumStatus.error);

                #endregion userLoginText *

                //TODO: Add Password Validation

                #region userPasswordText *

                if (!ValidationClass.IsValidString(inputModel.userPassword))
                    return BaseValid.createBaseValid(UsersMessagesAr.errorUserPasswordIsRequired, EnumStatus.error);

                #endregion userPasswordText *

                #region ValidLoginData *

                var isValidLoginData = IsValidLoginData(inputModel);
                if (isValidLoginData.Status != EnumStatus.success)
                    return isValidLoginData;

                #endregion ValidLoginData *

                return BaseValid.createBaseValid(UsersMessagesAr.loginSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid IsValidLoginData(UserLoginDto inputModel)
        {
            var hashedPassword = MethodsClass.Encrypt_Base64(inputModel.userPassword);

            var user = _unitOfWork.Users.FirstOrDefault(GetCriteria(inputModel, hashedPassword));

            if (user is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(UsersMessagesAr.errorInvalidUserLoginData, EnumStatus.error);
        }

        private static List<Expression<Func<User, bool>>> GetCriteria(UserLoginDto inputModel, string hashedPassword)
        {
            var criteria = new List<Expression<Func<User, bool>>>()
            {
                user => user.userPassword == hashedPassword,
                user => user.userLoginName == inputModel.userLoginText
                || user.userEmail == inputModel.userLoginText
                || user.userPhone == inputModel.userLoginText
            };

            return criteria;
        }
    }
}