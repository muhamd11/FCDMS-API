using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Helper.Validations;
using App.Core.Interfaces.UsersModule.UserTypes.UserProfiles;
using App.Core.Models.Buyers;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.General;

namespace Api.Controllers.UsersModules._01._1_UserTypes._01_UserProfile
{
    public class UserProfileValid : IUserProfileValid
    {
        #region Members

        public readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UserProfileValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region Methods

        public BaseValid IsValidUserProfile(UserProfile inputModel)
        {
            if (IsValidPhoneNumberSet(inputModel.userPhoneCC_2, inputModel.userPhoneDialCode_2, inputModel.userPhone_2))
                if (!ValidationClass.IsValidPhoneNumber(inputModel.userPhoneCC_2, inputModel.userPhoneDialCode_2, inputModel.userPhone_2))
                    return BaseValid.createBaseValid(string.Format(GeneralMessagesAr.ErrorInvalidPhoneNumbers, "2"), EnumStatus.error);

            if (IsValidPhoneNumberSet(inputModel.userPhoneCC_3, inputModel.userPhoneDialCode_3, inputModel.userPhone_3))
                if (!ValidationClass.IsValidPhoneNumber(inputModel.userPhoneCC_3, inputModel.userPhoneDialCode_3, inputModel.userPhone_3))
                    return BaseValid.createBaseValid(string.Format(GeneralMessagesAr.ErrorInvalidPhoneNumbers, "3"), EnumStatus.error);

            if (IsValidPhoneNumberSet(inputModel.userPhoneCC_4, inputModel.userPhoneDialCode_4, inputModel.userPhone_4))
                if (!ValidationClass.IsValidPhoneNumber(inputModel.userPhoneCC_4, inputModel.userPhoneDialCode_4, inputModel.userPhone_4))
                    return BaseValid.createBaseValid(string.Format(GeneralMessagesAr.ErrorInvalidPhoneNumbers, "4"), EnumStatus.error);

            if (inputModel.userContactEmail is not null)
                if (!ValidationClass.IsValidEmail(inputModel.userContactEmail))
                    return BaseValid.createBaseValid(GeneralMessagesAr.errorInvalidEmail, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
        }

        private bool IsValidPhoneNumberSet(string countryCode, string dialCode, string phoneNumber)
        {
            if (!string.IsNullOrEmpty(countryCode) && !string.IsNullOrEmpty(dialCode) && !string.IsNullOrEmpty(phoneNumber))
                return true;

            return false;
        }

        #endregion Methods
    }
}