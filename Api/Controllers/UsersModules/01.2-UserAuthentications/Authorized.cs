using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Consts.SystemBase;
using App.Core.Consts.Users;
using App.Core.Interfaces.GeneralInterfaces;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.General;
using App.Core.Resources.UsersModules.User;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications
{
    public class Authorized : IAuthorized
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHeaderRequest _headerRequest;

        public Authorized(IUnitOfWork unitOfWork, IHeaderRequest headerRequest)
        {
            _unitOfWork = unitOfWork;
            _headerRequest = headerRequest;
        }

        public BaseValid IsAuthorizedUser(string moduleToken, EnumFunctionsType functionsType, string? customFunctionId = null)
        {
            var userToken = _headerRequest.GetUserToken();
            if (userToken is null)
                return BaseValid.createBaseValid(UsersMessagesAr.errorUserAuthorizeTokenNotFound, EnumStatus.unauthorized);

            var user = _unitOfWork.Users.FirstOrDefault(x => x.userToken == userToken);
            if (user is null)
                return BaseValid.createBaseValid(UsersMessagesAr.errorUserDoesNotExists, EnumStatus.unauthorized);

            if (user.userTypeToken != EnumUserType.Developer)
            {
                var systemRoleFunction = customFunctionId is not null
                    ? _unitOfWork.SystemRoleFunctions.FirstOrDefault(x => x.systemRoleToken == user.systemRoleToken && x.moduleId == moduleToken && x.functionsType == functionsType && x.customizeFunctionId == customFunctionId)
                    : _unitOfWork.SystemRoleFunctions.FirstOrDefault(x => x.systemRoleToken == user.systemRoleToken && x.moduleId == moduleToken && x.functionsType == functionsType);

                if (systemRoleFunction?.isHavePrivilege != true)
                    return BaseValid.createBaseValidError(UsersMessagesAr.errorHasNoPermission);
            }

            return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
        }
    }
}