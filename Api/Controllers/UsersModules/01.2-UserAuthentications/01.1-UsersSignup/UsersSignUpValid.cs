using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Helper.Validations;
using App.Core.Interfaces.UsersModule.UserAuthentications.UsersSignUp;
using App.Core.Models.General.LocalModels;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;
using App.Core.Resources.General;
using App.Core.Resources.UsersModules.User;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications._01._0_UsersSignUp
{
    public class UsersSignUpValid : IUsersSignUpValid
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersSignUpValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BaseValid IsValidSignUp(UserSignUpDto inputModel)
        {
            if (inputModel is not null)
            {
                #region userName &&  userLoginName && userEmail

                if (!ValidationClass.IsValidString(inputModel.userLoginName) && !ValidationClass.IsValidString(inputModel.userEmail) && !ValidationClass.IsValidString(inputModel.userPhone))
                    return BaseValid.createBaseValidError(GeneralMessagesAr.errorSendLoginData);

                #endregion userName &&  userLoginName && userEmail

                #region userPassword *

                if (!ValidationClass.IsValidString(inputModel.userPassword))
                    return BaseValid.createBaseValid(GeneralMessagesAr.errorPasswordRequired, EnumStatus.error);

                #endregion userPassword *

                #region userName ?

                if (!ValidationClass.IsValidString(inputModel.userName))
                {
                    int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                    if (!ValidationClass.IsValidStringLength(inputModel.userName, nameMaxLength))
                        return BaseValid.createBaseValid(string.Format(GeneralMessagesAr.errorNameLength, nameMaxLength), EnumStatus.error);
                }

                #endregion userName ?

                #region userEmail ?

                if (ValidationClass.IsValidString(inputModel.userEmail) && !ValidationClass.IsValidEmail(inputModel.userEmail))
                    return BaseValid.createBaseValid(GeneralMessagesAr.errorInvalidEmail, EnumStatus.error);

                #endregion userEmail ?

                #region userPhoneNumber *

                if (ValidationClass.IsValidString(inputModel.userPhone) && !ValidationClass.IsValidPhoneNumber(inputModel.userPhoneCC, inputModel.userPhone))
                    return BaseValid.createBaseValid(GeneralMessagesAr.ErrorInvalidPhoneNumber, EnumStatus.error);

                #endregion userPhoneNumber *

                #region validUserWasAddedBefore

                var existingUser = _unitOfWork.Users.FirstOrDefault(x => x.userName == inputModel.userName
                                    || x.userEmail == inputModel.userEmail
                                    || x.userPhone == inputModel.userPhone
                                    || x.userLoginName == inputModel.userLoginName);

                if (existingUser is not null && existingUser.userName == inputModel.userName)
                    return BaseValid.createBaseValid(UsersMessagesAr.errorUsernameWasAdded, EnumStatus.error);

                if (existingUser is not null && existingUser.userEmail == inputModel.userEmail)
                    return BaseValid.createBaseValid(UsersMessagesAr.errorUserEmailWasAdded, EnumStatus.error);

                if (existingUser is not null && existingUser.userPhone == inputModel.userPhone)
                    return BaseValid.createBaseValid(UsersMessagesAr.errorUserPhoneNumberWasAdded, EnumStatus.error);

                if (existingUser is not null && existingUser.userLoginName == inputModel.userLoginName)
                    return BaseValid.createBaseValid(UsersMessagesAr.errorUserLoginNameWasAdded, EnumStatus.error);

                #endregion validUserWasAddedBefore

                return BaseValid.createBaseValid(UsersMessagesAr.signupSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }
    }
}