using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Helper.Validations;
using App.Core.Interfaces.UsersModule.UserTypes.UserProfiles;
using App.Core.Models.General.LocalModels;
using App.Core.Models.UsersModule._01_1_UserTypes;
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
            var isValidProfileData = CheckProfileData(inputModel);

            if (isValidProfileData.Status != EnumStatus.success)
                return isValidProfileData;

            return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
        }

        private BaseValid CheckProfileData(UserProfile inputModel)
        {
            if (IsValidPhoneNumberSet(inputModel.userPhoneCC2, inputModel.userPhone2) && !ValidationClass.IsValidPhoneNumber(inputModel.userPhoneCC2, inputModel.userPhone2))
                return BaseValid.createBaseValid(string.Format(GeneralMessagesAr.ErrorInvalidPhoneNumbers, "2"), EnumStatus.error);

            if (IsValidPhoneNumberSet(inputModel.userPhoneCC3, inputModel.userPhone3) && !ValidationClass.IsValidPhoneNumber(inputModel.userPhoneCC3, inputModel.userPhone3))
                return BaseValid.createBaseValid(string.Format(GeneralMessagesAr.ErrorInvalidPhoneNumbers, "3"), EnumStatus.error);

            if (IsValidPhoneNumberSet(inputModel.userPhoneCC4, inputModel.userPhone4) && !ValidationClass.IsValidPhoneNumber(inputModel.userPhoneCC4, inputModel.userPhone4))
                return BaseValid.createBaseValid(string.Format(GeneralMessagesAr.ErrorInvalidPhoneNumbers, "4"), EnumStatus.error);

            if (ValidationClass.IsValidString(inputModel.userContactEmail) && !ValidationClass.IsValidEmail(inputModel.userContactEmail))
                return BaseValid.createBaseValid(GeneralMessagesAr.errorInvalidContactEmail, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
        }

        private bool IsValidPhoneNumberSet(string countryCode, string phoneNumber)
        {
            if (!string.IsNullOrEmpty(countryCode) && !string.IsNullOrEmpty(phoneNumber))
                return true;

            return false;
        }

        #endregion Methods
    }
}