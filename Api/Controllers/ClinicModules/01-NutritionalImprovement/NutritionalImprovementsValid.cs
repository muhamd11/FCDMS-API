using Api.Controllers.UsersModules.Users.Interfaces;
using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.NutritionalImprovements;
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

        #endregion Members

        #region Constructor

        public NutritionalImprovementValid(IUnitOfWork unitOfWork, IUsersValid usersValid)
        {
            _unitOfWork = unitOfWork;
            _usersValid = usersValid;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidGetAll(BaseSearchDto inputModel)
        {
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
            if (inputModel is not null)
            {
                #region nutritionalImprovementId?

                if (isUpdate)
                {
                    var isValidNutritionalImprovementToken = ValidNutritionalImprovementToken(inputModel.nutritionalImprovementToken);
                    if (isValidNutritionalImprovementToken.Status != EnumStatus.success)
                        return isValidNutritionalImprovementToken;
                }

                #endregion nutritionalImprovementId?

                #region userPatientToken *

                var isValidUser = _usersValid.IsValidUserToken(inputModel.userPatientToken);
                if (isValidUser.Status != EnumStatus.success)
                    return isValidUser;

                #endregion

                // TODO: Add validations for NutritionalImprovement

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
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