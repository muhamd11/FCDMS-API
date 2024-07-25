using Api.Controllers.SystemBase.LogActions.Interfaces;
using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.SystemRoles;
using App.Core.Models.General.LocalModels;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.DTO;
using App.Core.Resources.General;

namespace Api.Controllers.SystemBase.SystemRoleFunctions
{
    internal class SystemRoleFunctionValid : ISystemRoleFunctionsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemRolesValid _systemRolesValid;

        #endregion Members

        #region Constructor

        public SystemRoleFunctionValid(IUnitOfWork unitOfWork, ISystemRolesValid systemRolesValid)
        {
            _unitOfWork = unitOfWork;
            _systemRolesValid = systemRolesValid;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidGetDetails(Guid systemRoleToken)
        {
            var isValidSystemRoleToken = _systemRolesValid.ValidSystemRoleToken(systemRoleToken);

            if (isValidSystemRoleToken.Status != EnumStatus.success)
                return isValidSystemRoleToken;

            return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
        }

        public BaseValid ValidUpdatePrivilege(SystemRoleFunctionDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidSystemRoleToken = _systemRolesValid.ValidSystemRoleToken(inputModel.systemRoleToken);

                if (isValidSystemRoleToken.Status != EnumStatus.success)
                    return isValidSystemRoleToken;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        #endregion Methods
    }
}