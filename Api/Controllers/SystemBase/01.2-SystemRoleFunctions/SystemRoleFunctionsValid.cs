using Api.Controllers.SystemBase.LogActions.Interfaces;
using App.Core.Consts.GeneralModels;
using App.Core.Consts.SystemBase;
using App.Core.Interfaces.SystemBase.SystemRoles;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.General.LocalModels;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.DTO;
using App.Core.Resources.General;

namespace Api.Controllers.SystemBase.SystemRoleFunctions
{
    internal class SystemRoleFunctionValid : ISystemRoleFunctionsValid
    {
        #region Members

        private readonly ISystemRolesValid _systemRolesValid;
        private readonly IUserAuthenticationValid _userAuthenticationValid;

        private readonly string SystemRoleFunctionView = $"{nameof(SystemRoleFunction)}_{nameof(EnumFunctionsType.view)}";
        private readonly string SystemRoleFunctionUpdate = $"{nameof(SystemRoleFunction)}_{nameof(EnumFunctionsType.update)}";

        #endregion Members

        #region Constructor

        public SystemRoleFunctionValid(ISystemRolesValid systemRolesValid, IUserAuthenticationValid userAuthenticationValid)
        {
            _systemRolesValid = systemRolesValid;
            _userAuthenticationValid = userAuthenticationValid;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidGetDetails(Guid systemRoleToken)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _userAuthenticationValid.IsAuthorizedUser(SystemRoleFunctionView);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            var isValidSystemRoleToken = _systemRolesValid.ValidSystemRoleToken(systemRoleToken);

            if (isValidSystemRoleToken.Status != EnumStatus.success)
                return isValidSystemRoleToken;

            return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
        }

        public BaseValid ValidUpdatePrivilege(SystemRoleFunctionDto inputModel)
        {
            #region isAuthorizedUser *]

            var isAuthorizedUser = _userAuthenticationValid.IsAuthorizedUser(SystemRoleFunctionUpdate);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *]

            if (inputModel is not null)
            {
                var isValidSystemRoleToken = _systemRolesValid.ValidSystemRoleToken(inputModel.systemRoleToken);

                if (isValidSystemRoleToken.Status != EnumStatus.success)
                    return isValidSystemRoleToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        #endregion Methods
    }
}