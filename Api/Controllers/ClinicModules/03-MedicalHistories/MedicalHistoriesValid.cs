using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.MedicalHistories;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.ClinicModules.MedicalHistories;
using App.Core.Resources.General;

namespace Api.Controllers.SystemBase.MedicalHistories
{
    internal class MedicalHistoryValid : IMedicalHistoriesValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public MedicalHistoryValid(IUnitOfWork unitOfWork)
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
                    var isValidMedicalHistoryToken = ValidMedicalHistoryToken((Guid)inputModel.elementToken);
                    if (isValidMedicalHistoryToken.Status != EnumStatus.success)
                        return isValidMedicalHistoryToken;
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
                var isValidMedicalHistoryToken = ValidMedicalHistoryToken(inputModel.elementToken);
                if (isValidMedicalHistoryToken.Status != EnumStatus.success)
                    return isValidMedicalHistoryToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(MedicalHistoryAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region medicalHistoryId?

                if (isUpdate)
                {
                    var isValidMedicalHistoryToken = ValidMedicalHistoryToken(inputModel.medicalHistoryToken);
                    if (isValidMedicalHistoryToken.Status != EnumStatus.success)
                        return isValidMedicalHistoryToken;
                }

                #endregion medicalHistoryId?

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidMedicalHistoryToken = ValidMedicalHistoryToken(inputModel.elementToken);
                if (isValidMedicalHistoryToken.Status != EnumStatus.success)
                    return isValidMedicalHistoryToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidMedicalHistoryToken(Guid medicalHistoryToken)
        {
            var medicalHistory = _unitOfWork.MedicalHistories.FirstOrDefault(x => x.medicalHistoryToken == medicalHistoryToken);
            if (medicalHistory is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(MedicalHistoriesMessagesAr.errorMedicalHistoryWasNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}