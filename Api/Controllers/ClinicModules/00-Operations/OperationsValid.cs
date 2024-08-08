using Api.Controllers.UsersModules.Users.Interfaces;
using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Consts.SystemBase;
using App.Core.Helper.Validations;
using App.Core.Interfaces.SystemBase.Operations;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.OperationsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.ClinicModules.Operations;
using App.Core.Resources.General;

namespace Api.Controllers.SystemBase.Operations
{
    internal class OperationValid : IOperationsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersValid _usersValid;
        private readonly IAuthorized _authorized;
        private readonly string moduleToken = nameof(Operation);

        #endregion Members

        #region Constructor

        public OperationValid(IUnitOfWork unitOfWork, IUsersValid usersValid, IAuthorized authorized)
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
                    var isValidOperationToken = ValidOperationToken((Guid)inputModel.elementToken);
                    if (isValidOperationToken.Status != EnumStatus.success)
                        return isValidOperationToken;
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
                #region isAuthorizedUser *

                var isAuthorizedUser = _authorized.IsAuthorizedUser(moduleToken, EnumFunctionsType.view);
                if (isAuthorizedUser.Status != EnumStatus.success)
                    return isAuthorizedUser;

                #endregion isAuthorizedUser *

                var isValidOperationToken = ValidOperationToken(inputModel.elementToken);
                if (isValidOperationToken.Status != EnumStatus.success)
                    return isValidOperationToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(OperationAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region isAuthorizedUser *

                var isAuthorizedUser = _authorized.IsAuthorizedUser(moduleToken, isUpdate ? EnumFunctionsType.update : EnumFunctionsType.add);
                if (isAuthorizedUser.Status != EnumStatus.success)
                    return isAuthorizedUser;

                #endregion isAuthorizedUser *

                if (isUpdate)
                {
                    #region operationId?

                    var isValidOperationToken = ValidOperationToken(inputModel.operationToken);
                    if (isValidOperationToken.Status != EnumStatus.success)
                        return isValidOperationToken;

                    #endregion operationId?
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

                #region operationName *

                if (!ValidationClass.IsValidString(inputModel.operationName))
                    return BaseValid.createBaseValid(OperationsMessagesAr.errorOperationNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.operationName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessagesAr.errorNameLength, nameMaxLength), EnumStatus.error);

                #endregion operationName *

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        private BaseValid validFullCode(OperationAddOrUpdateDTO inputModel)
        {
            var fullCode = _unitOfWork.Operations.FirstOrDefault(x => x.fullCode == inputModel.fullCode);

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
                var isValidOperationToken = ValidOperationToken(inputModel.elementToken);
                if (isValidOperationToken.Status != EnumStatus.success)
                    return isValidOperationToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidOperationToken(Guid operationToken)
        {
            var operation = _unitOfWork.Operations.FirstOrDefault(x => x.operationToken == operationToken);
            if (operation is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(OperationsMessagesAr.errorOperationWasNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}