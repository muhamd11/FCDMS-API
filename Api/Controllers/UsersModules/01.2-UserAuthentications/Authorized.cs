using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Helper.Json;
using App.Core.Helper.Validations;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.General;
using App.Core.Resources.UsersModules.User;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications
{
    public class Authorized
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Authorized(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public BaseValid IsAuthorizedUser(string functionFullId)
        {
            var userAuthorizeToken = GetUserAuthorizeToken();
            if (!ValidationClass.IsValidString(userAuthorizeToken))
                return BaseValid.createBaseValidError(UsersMessagesAr.errorUserAuthorizeTokenNotFound);

            var userAuthorize = JsonConversion.DeserializeUserAuthorizeToken(userAuthorizeToken!);

            var user = _unitOfWork.Users.FirstOrDefault(x => x.userToken == userAuthorize.userToken);

            if (user == null)
                return BaseValid.createBaseValidError(UsersMessagesAr.errorUserDoesNotExists);

            var systemRoleFunction = _unitOfWork.SystemRoleFunctions.FirstOrDefault(x => x.systemRoleToken == user.systemRoleToken && x.functionId == functionFullId);

            if (systemRoleFunction?.isHavePrivilege != true)
                return BaseValid.createBaseValidError(UsersMessagesAr.errorHasNoPermission);

            return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
        }

        private string? GetUserAuthorizeToken()
            => _httpContextAccessor?.HttpContext?.Request.Headers["userAuthorizeToken"].FirstOrDefault();
    }
}