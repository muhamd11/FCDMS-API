using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Helper;
using App.Core.Helper.Json;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.General.LocalModels;
using App.Core.Models.GeneralModels.BaseRequestHeaderModules;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Resources.General;
using App.Core.Resources.UsersModules.User;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications
{
    public class UsersAuthValid : IUserAuthValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;


        #endregion

        #region Constructor

        public UsersAuthValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion


        #region Methods

        public BaseValid IsAuthenticated(BaseRequestHeaders inputModel)
        {
            if (inputModel is not null)
            {
                if (inputModel.userAuthorizeToken == null)
                    return BaseValid.createBaseValid(UsersMessagesAr.errorUserAuthorizeTokenNotFound, EnumStatus.error);

                var userAuthorize = JsonConversion.DeserializeUserAuthorizeToken(inputModel.userAuthorizeToken);

                var user = _unitOfWork.Users.Any(x => x.userToken == userAuthorize.userToken);

                if (user)
                    return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
                else
                    return BaseValid.createBaseValid(UsersMessagesAr.errorInvalidUserAuthorizeToken, EnumStatus.error);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorHeaderNotFound, EnumStatus.error);
        }

        #endregion
    }
}
