using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Helper.Validations;
using App.Core.Interfaces.SystemBase.SystemRoles;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.SystemBase.Roles;
using App.Core.Models.SystemBase.Roles.DTO;
using App.Core.Resources.General;
using App.Core.Resources.SystemBase.SystemRoles;

namespace Api.Controllers.SystemBase.SystemRoles
{
    internal class SystemRoleValid : ISystemRolesValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public SystemRoleValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                    var isValidSystemRoleToken = ValidSystemRoleToken((Guid)inputModel.elementToken);
                    if (isValidSystemRoleToken.Status != EnumStatus.success)
                        return isValidSystemRoleToken;
                }

                #endregion elemetId?

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidSystemRoleToken = ValidSystemRoleToken(inputModel.elementToken);
                if (isValidSystemRoleToken.Status != EnumStatus.success)
                    return isValidSystemRoleToken;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(SystemRoleAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region systemRoleId?

                if (isUpdate)
                {
                    var isValidSystemRoleToken = ValidSystemRoleToken(inputModel.systemRoleToken);
                    if (isValidSystemRoleToken.Status != EnumStatus.success)
                        return isValidSystemRoleToken;
                }

                #endregion systemRoleId?

                #region systemRoleName *

                if (!ValidationClass.IsValidString(inputModel.systemRoleName))
                    return BaseValid.createBaseValid(SystemRolesMessages.errorSystemRoleNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.systemRoleName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);

                #endregion systemRoleName *

                #region ValidateSystemRole

                var isValidSystemRole = IsValidSystemRole(inputModel);

                if (isValidSystemRole.Status != EnumStatus.success)
                    return isValidSystemRole;

                #endregion ValidateSystemRole

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidSystemRoleToken = ValidSystemRoleToken(inputModel.elementToken);
                if (isValidSystemRoleToken.Status != EnumStatus.success)
                    return isValidSystemRoleToken;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidSystemRoleToken(Guid systemRoleToken)
        {
            var systemRole = _unitOfWork.SystemRoles.FirstOrDefault(x => x.systemRoleToken == systemRoleToken);
            if (systemRole is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(SystemRolesMessages.errorSystemRoleWasNotFound, EnumStatus.error);
        }

        public BaseValid IsValidSystemRole(SystemRoleAddOrUpdateDTO inputModel)
        {
            SystemRole existingSystemRole;

            existingSystemRole = _unitOfWork.SystemRoles.FirstOrDefault(x => x.systemRoleName == inputModel.systemRoleName);
            if (existingSystemRole is not null && existingSystemRole.systemRoleToken != inputModel.systemRoleToken)
                return BaseValid.createBaseValid(SystemRolesMessages.errorSystemRoleNameWasAdded, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
        }

        #endregion Methods
    }
}