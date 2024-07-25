using Api.Controllers.UsersModules.Users.Interfaces;
using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Models.General.LocalModels;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;
using App.Core.Resources.General;

namespace Api.Controllers.UsersModule.Users
{
    internal class UserClientValid : IUserPatientsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UserClientValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region Methods

        public BaseValid IsValidUserClient(UserPatient inputModel)
        {
            if (inputModel is not null)
            {
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        #endregion Methods
    }
}