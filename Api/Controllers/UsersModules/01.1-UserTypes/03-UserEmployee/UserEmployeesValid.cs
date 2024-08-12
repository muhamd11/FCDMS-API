using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.UsersModule.UserTypes.UserEmployees;
using App.Core.Models.General.LocalModels;
using App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee;
using App.Core.Resources.General;
using App.Core.Resources.UsersModules.UserTypes.UserEmployee;

namespace Api.Controllers.UsersModule.Users
{
    internal class UserEmployeesValid : IUserEmployeesValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UserEmployeesValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region Methods

        public BaseValid IsValidUserEmployee(UserEmployee inputModel)
        {
            if (inputModel is not null)
            {
                if (!long.TryParse(inputModel.userNationalId, out _))
                    return BaseValid.createBaseValid(UsersEmployeeMessagesAr.nationalIdNotValid, EnumStatus.error);

                #region validUserNationalIdWasAddedBefore

                var existingUser = _unitOfWork.UserEmployees.FirstOrDefault(x => x.userToken == inputModel.userToken && x.userNationalId == inputModel.userNationalId);

                if (existingUser is not null)
                    return BaseValid.createBaseValid(UsersEmployeeMessagesAr.nationalIdAlreadyAddedBefore, EnumStatus.error);

                #endregion validUserNationalIdWasAddedBefore

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        #endregion Methods
    }
}