using Api.Controllers.UsersModules.Users.Interfaces;
using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.LogActions;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.SystemBase.LogActions.DTO;
using App.Core.Resources.General;
using App.Core.Resources.SystemBase.LogActions;

namespace Api.Controllers.SystemBase.LogActions
{
    internal class LogActionValid : ILogActionsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersValid _usersValid;

        #endregion Members

        #region Constructor

        public LogActionValid(IUnitOfWork unitOfWork, IUsersValid usersValid)
        {
            _unitOfWork = unitOfWork;
            _usersValid = usersValid;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidGetAll(LogActionSearchDto inputModel)
        {
            if (inputModel is not null)
            {
                #region elemetId?

                if (inputModel.elementToken is not null)
                {
                    var isValidLogActionToken = ValidLogActionToken((Guid)inputModel.elementToken);
                    if (isValidLogActionToken.Status != EnumStatus.success)
                        return isValidLogActionToken;
                }

                #endregion elemetId?


                #region userToken ? 

                if (inputModel.userToken.HasValue)
                {
                    var isValidUserToken = _usersValid.IsValidUserToken(inputModel.userToken.Value);
                    if (isValidUserToken.Status != EnumStatus.success)
                        return isValidUserToken;
                }

                #endregion userToken ?

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidLogActionToken = ValidLogActionToken(inputModel.elementToken);
                if (isValidLogActionToken.Status != EnumStatus.success)
                    return isValidLogActionToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidLogActionToken(Guid logActionToken)
        {
            var logAction = _unitOfWork.LogActions.FirstOrDefault(x => x.logActionToken == logActionToken);
            if (logAction is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(LogActionsMessagesAr.errorLogActionWasNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}