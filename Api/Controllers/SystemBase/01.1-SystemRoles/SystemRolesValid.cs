using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Consts.SystemBase;
using App.Core.Helper.Validations;
using App.Core.Interfaces.SystemBase.SystemRoles;
using App.Core.Interfaces.UsersModule.UserAuthentications;
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
        private readonly IAuthorized _authorized;

        private readonly string systemRoleView = $"{nameof(SystemRole)}_{nameof(EnumFunctionsType.view)}";
        private readonly string systemRoleAdd = $"{nameof(SystemRole)}_{nameof(EnumFunctionsType.add)}";
        private readonly string systemRoleUpdate = $"{nameof(SystemRole)}_{nameof(EnumFunctionsType.update)}";
        private readonly string systemRoleDelete = $"{nameof(SystemRole)}_{nameof(EnumFunctionsType.delete)}";

        #endregion Members

        #region Constructor

        public SystemRoleValid(IUnitOfWork unitOfWork, IAuthorized authorized)
        {
            _unitOfWork = unitOfWork;
            _authorized = authorized;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidGetAll(BaseSearchDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(systemRoleView);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

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

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(systemRoleView);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                var isValidSystemRoleToken = ValidSystemRoleToken(inputModel.elementToken);
                if (isValidSystemRoleToken.Status != EnumStatus.success)
                    return isValidSystemRoleToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(SystemRoleAddOrUpdateDTO inputModel, bool isUpdate)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(isUpdate ? systemRoleUpdate : systemRoleAdd);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                if (isUpdate)
                {

                    #region systemRoleId?

                    var isValidSystemRoleToken = ValidSystemRoleToken(inputModel.systemRoleToken);
                    if (isValidSystemRoleToken.Status != EnumStatus.success)
                        return isValidSystemRoleToken;

                    #endregion systemRoleId?
                }

                #region systemRoleName *

                if (!ValidationClass.IsValidString(inputModel.systemRoleName))
                    return BaseValid.createBaseValid(SystemRolesMessagesAr.errorSystemRoleNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.systemRoleName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessagesAr.errorNameLength, nameMaxLength), EnumStatus.error);

                #endregion systemRoleName *

                #region ValidateSystemRole

                var isValidSystemRole = IsValidSystemRole(inputModel);

                if (isValidSystemRole.Status != EnumStatus.success)
                    return isValidSystemRole;

                #endregion ValidateSystemRole

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(systemRoleDelete);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                var isValidSystemRoleToken = ValidSystemRoleToken(inputModel.elementToken);
                if (isValidSystemRoleToken.Status != EnumStatus.success)
                    return isValidSystemRoleToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidSystemRoleToken(Guid? systemRoleToken)
        {
            var systemRole = _unitOfWork.SystemRoles.FirstOrDefault(x => x.systemRoleToken == systemRoleToken);
            if (systemRole is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(SystemRolesMessagesAr.errorSystemRoleWasNotFound, EnumStatus.error);
        }

        public BaseValid IsValidSystemRole(SystemRoleAddOrUpdateDTO inputModel)
        {
            SystemRole existingSystemRole;

            existingSystemRole = _unitOfWork.SystemRoles.FirstOrDefault(x => x.systemRoleName == inputModel.systemRoleName);
            if (existingSystemRole is not null && existingSystemRole.systemRoleToken != inputModel.systemRoleToken)
                return BaseValid.createBaseValid(SystemRolesMessagesAr.errorSystemRoleNameWasAdded, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
        }

        #endregion Methods
    }
}