using Api.Controllers.UsersModules.Users.Interfaces;
using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Consts.SystemBase;
using App.Core.Interfaces.SystemBase.NutritionalImprovements;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.ClinicModules.NutritionalImprovements;
using App.Core.Resources.General;

namespace Api.Controllers.SystemBase.NutritionalImprovements
{
    internal class NutritionalImprovementValid : INutritionalImprovementsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersValid _usersValid;
        private readonly IUserAuthenticationValid _userAuthenticationValid;

        private readonly string nutritionalImprovementView = $"{nameof(NutritionalImprovement)}_{nameof(EnumFunctionsType.view)}";
        private readonly string nutritionalImprovementAdd = $"{nameof(NutritionalImprovement)}_{nameof(EnumFunctionsType.add)}";
        private readonly string nutritionalImprovementUpdate = $"{nameof(NutritionalImprovement)}_{nameof(EnumFunctionsType.update)}";
        private readonly string nutritionalImprovementDelete = $"{nameof(NutritionalImprovement)}_{nameof(EnumFunctionsType.delete)}";

        #endregion Members

        #region Constructor

        public NutritionalImprovementValid(IUnitOfWork unitOfWork, IUsersValid usersValid, IUserAuthenticationValid userAuthenticationValid)
        {
            _unitOfWork = unitOfWork;
            _usersValid = usersValid;
            _userAuthenticationValid = userAuthenticationValid;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidGetAll(BaseSearchDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _userAuthenticationValid.IsAuthorizedUser(nutritionalImprovementView);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                #region elemetId?

                if (inputModel.elementToken is not null)
                {
                    var isValidNutritionalImprovementToken = ValidNutritionalImprovementToken((Guid)inputModel.elementToken);
                    if (isValidNutritionalImprovementToken.Status != EnumStatus.success)
                        return isValidNutritionalImprovementToken;
                }

                #endregion elemetId?

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _userAuthenticationValid.IsAuthorizedUser(nutritionalImprovementView);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                var isValidNutritionalImprovementToken = ValidNutritionalImprovementToken(inputModel.elementToken);
                if (isValidNutritionalImprovementToken.Status != EnumStatus.success)
                    return isValidNutritionalImprovementToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(NutritionalImprovementAddOrUpdateDTO inputModel, bool isUpdate)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _userAuthenticationValid.IsAuthorizedUser(nutritionalImprovementAdd);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                if (isUpdate)
                {
                    #region isAuthorizedUser *

                    isAuthorizedUser = _userAuthenticationValid.IsAuthorizedUser(nutritionalImprovementUpdate);

                    if (isAuthorizedUser.Status != EnumStatus.success)
                        return isAuthorizedUser;

                    #endregion isAuthorizedUser *

                    #region nutritionalImprovementId?

                    var isValidNutritionalImprovementToken = ValidNutritionalImprovementToken(inputModel.nutritionalImprovementToken);
                    if (isValidNutritionalImprovementToken.Status != EnumStatus.success)
                        return isValidNutritionalImprovementToken;

                    #endregion nutritionalImprovementId?
                }

                #region userPatientToken *

                var isValidUser = _usersValid.IsValidUserToken(inputModel.userPatientToken);
                if (isValidUser.Status != EnumStatus.success)
                    return isValidUser;

                #endregion userPatientToken *

                #region fullCode *

                var isValidFullCode = validFullCode(inputModel);
                if (isValidFullCode.Status != EnumStatus.success)
                    return isValidFullCode;

                #endregion fullCode *

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        private BaseValid validFullCode(NutritionalImprovementAddOrUpdateDTO inputModel)
        {
            var fullCode = _unitOfWork.NutritionalImprovements.FirstOrDefault(x => x.fullCode == inputModel.fullCode);

            if (fullCode is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.errorFullCodeExists, EnumStatus.error);
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _userAuthenticationValid.IsAuthorizedUser(nutritionalImprovementDelete);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                var isValidNutritionalImprovementToken = ValidNutritionalImprovementToken(inputModel.elementToken);
                if (isValidNutritionalImprovementToken.Status != EnumStatus.success)
                    return isValidNutritionalImprovementToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidNutritionalImprovementToken(Guid nutritionalImprovementToken)
        {
            var nutritionalImprovement = _unitOfWork.NutritionalImprovements.FirstOrDefault(x => x.nutritionalImprovementToken == nutritionalImprovementToken);
            if (nutritionalImprovement is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(NutritionalImprovementsMessagesAr.errorNutritionalImprovementWasNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}