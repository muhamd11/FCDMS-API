using Api.Controllers.UsersModules.Users.Interfaces;
using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Consts.SystemBase;
using App.Core.Interfaces.SystemBase.Visits;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.ClinicModules.VisitsModules;
using App.Core.Models.ClinicModules.VisitsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.ClinicModules.Visits;
using App.Core.Resources.General;

namespace Api.Controllers.SystemBase.Visits
{
    internal class VisitValid : IVisitsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersValid _usersValid;
        private readonly IAuthorized _authorized;

        private readonly string visitView = $"{nameof(Visit)}_{nameof(EnumFunctionsType.view)}";
        private readonly string visitAdd = $"{nameof(Visit)}_{nameof(EnumFunctionsType.add)}";
        private readonly string visitUpdate = $"{nameof(Visit)}_{nameof(EnumFunctionsType.update)}";
        private readonly string visitDelete = $"{nameof(Visit)}_{nameof(EnumFunctionsType.delete)}";

        #endregion Members

        #region Constructor

        public VisitValid(IUnitOfWork unitOfWork, IUsersValid usersValid, IAuthorized authorized)
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

            var isAuthorizedUser = _authorized.IsAuthorizedUser(visitView);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                #region elemetId?

                if (inputModel.elementToken is not null)
                {
                    var isValidVisitToken = ValidVisitToken((Guid)inputModel.elementToken);
                    if (isValidVisitToken.Status != EnumStatus.success)
                        return isValidVisitToken;
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

            var isAuthorizedUser = _authorized.IsAuthorizedUser(visitView);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                var isValidVisitToken = ValidVisitToken(inputModel.elementToken);
                if (isValidVisitToken.Status != EnumStatus.success)
                    return isValidVisitToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(VisitAddOrUpdateDTO inputModel, bool isUpdate)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(isUpdate ? visitUpdate : visitAdd);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                if (isUpdate)
                {
                    #region VisitId?

                    var isValidVisitToken = ValidVisitToken(inputModel.visitToken);
                    if (isValidVisitToken.Status != EnumStatus.success)
                        return isValidVisitToken;

                    #endregion VisitId?
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

        private BaseValid validFullCode(VisitAddOrUpdateDTO inputModel)
        {
            var fullCode = _unitOfWork.Visits.FirstOrDefault(x => x.fullCode == inputModel.fullCode);

            if (fullCode is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.errorFullCodeExists, EnumStatus.error);
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(visitDelete);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                var isValidVisitToken = ValidVisitToken(inputModel.elementToken);
                if (isValidVisitToken.Status != EnumStatus.success)
                    return isValidVisitToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidVisitToken(Guid visitToken)
        {
            var Visit = _unitOfWork.Visits.FirstOrDefault(x => x.visitToken == visitToken);
            if (Visit is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(VisitsMessagesAr.errorVisitWasNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}