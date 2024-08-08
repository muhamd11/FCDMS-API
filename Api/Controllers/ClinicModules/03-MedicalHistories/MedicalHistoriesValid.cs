using Api.Controllers.UsersModules.Users.Interfaces;
using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Consts.SystemBase;
using App.Core.Interfaces.SystemBase.MedicalHistories;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.ClinicModules.MedicalHistoriesModules;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.ClinicModules.MedicalHistories;
using App.Core.Resources.General;

namespace Api.Controllers.SystemBase.MedicalHistories
{
    internal class MedicalHistoryValid : IMedicalHistoriesValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersValid _usersValid;
        private readonly IAuthorized _authorized;
        private readonly string moduleToken = nameof(MedicalHistory);

        #endregion Members

        #region Constructor

        public MedicalHistoryValid(IUnitOfWork unitOfWork, IUsersValid usersValid, IAuthorized authorized)
        {
            _unitOfWork = unitOfWork;
            _usersValid = usersValid;
            _authorized = authorized;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidGetAll(BaseSearchDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(moduleToken, EnumFunctionsType.view);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                #region elemetId?

                if (inputModel.elementToken is not null)
                {
                    var isValidMedicalHistoryToken = ValidMedicalHistoryToken((Guid)inputModel.elementToken);
                    if (isValidMedicalHistoryToken.Status != EnumStatus.success)
                        return isValidMedicalHistoryToken;
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

            var isAuthorizedUser = _authorized.IsAuthorizedUser(moduleToken, EnumFunctionsType.view);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                var isValidMedicalHistoryToken = ValidMedicalHistoryToken(inputModel.elementToken);
                if (isValidMedicalHistoryToken.Status != EnumStatus.success)
                    return isValidMedicalHistoryToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(MedicalHistoryAddOrUpdateDTO inputModel, bool isUpdate)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(moduleToken, isUpdate ? EnumFunctionsType.update : EnumFunctionsType.add);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                if (isUpdate)
                {
                    #region MedicalHistoryId?

                    var isValidMedicalHistoryToken = ValidMedicalHistoryToken(inputModel.medicalHistoryToken);
                    if (isValidMedicalHistoryToken.Status != EnumStatus.success)
                        return isValidMedicalHistoryToken;

                    #endregion MedicalHistoryId?
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

        private BaseValid validFullCode(MedicalHistoryAddOrUpdateDTO inputModel)
        {
            var fullCode = _unitOfWork.MedicalHistories.FirstOrDefault(x => x.fullCode == inputModel.fullCode);

            if (fullCode is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.errorFullCodeExists, EnumStatus.error);
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(moduleToken, EnumFunctionsType.delete);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                var isValidMedicalHistoryToken = ValidMedicalHistoryToken(inputModel.elementToken);
                if (isValidMedicalHistoryToken.Status != EnumStatus.success)
                    return isValidMedicalHistoryToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidMedicalHistoryToken(Guid medicalHistoryToken)
        {
            var medicalHistory = _unitOfWork.MedicalHistories.FirstOrDefault(x => x.medicalHistoryToken == medicalHistoryToken);
            if (medicalHistory is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(MedicalHistoriesMessagesAr.errorMedicalHistoryWasNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}