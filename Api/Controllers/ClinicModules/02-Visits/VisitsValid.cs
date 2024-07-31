using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.Visits;
using App.Core.Models.ClinicModules.VisitsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.ClinicModules.Visits;
using App.Core.Resources.General;

namespace Api.Controllers.SystemBase.Visits
{
    internal class VisitValid : IVisitsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public VisitValid(IUnitOfWork unitOfWork)
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
                    var isValidVisitToken = ValidVisitToken((Guid)inputModel.elementToken);
                    if (isValidVisitToken.Status != EnumStatus.success)
                        return isValidVisitToken;
                }

                #endregion elemetId?

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidVisitToken = ValidVisitToken(inputModel.elementToken);
                if (isValidVisitToken.Status != EnumStatus.success)
                    return isValidVisitToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(VisitAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region visitId?

                if (isUpdate)
                {
                    var isValidVisitToken = ValidVisitToken(inputModel.visitToken);
                    if (isValidVisitToken.Status != EnumStatus.success)
                        return isValidVisitToken;
                }

                #endregion visitId?

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidVisitToken = ValidVisitToken(inputModel.elementToken);
                if (isValidVisitToken.Status != EnumStatus.success)
                    return isValidVisitToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidVisitToken(Guid visitToken)
        {
            var visit = _unitOfWork.Visits.FirstOrDefault(x => x.visitToken == visitToken);
            if (visit is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(VisitsMessagesAr.errorVisitWasNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}