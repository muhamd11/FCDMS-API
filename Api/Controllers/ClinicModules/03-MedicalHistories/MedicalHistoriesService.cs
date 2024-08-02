using App.Core;
using App.Core.Interfaces.SystemBase.MedicalHistories;
using App.Core.Models.ClinicModules.MedicalHistoriesModules;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.DTO;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.ViewModel;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.General.PaginationModule;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.MedicalHistories
{
    internal class MedicalHistoryService : IMedicalHistoriesServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public MedicalHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<MedicalHistoryInfoDetails> GetDetails(MedicalHistoryGetDetailsDTO inputModel)
        {
            var select = MedicalHistoriesAdaptor.SelectExpressionMedicalHistoryInfoDetails();

            Expression<Func<MedicalHistory, bool>> criteria = (x) => x.medicalHistoryToken == inputModel.elementToken;

            var medicalHistoryInfo = await _unitOfWork.MedicalHistories.FirstOrDefaultAsync(criteria, select);

            return medicalHistoryInfo;
        }

        public async Task<BaseGetDataWithPagnation<MedicalHistoryInfo>> GetAllAsync(MedicalHistorySearchDTO inputModel)
        {
            var select = MedicalHistoriesAdaptor.SelectExpressionMedicalHistoryInfo(inputModel.includeUserPatientInfoData);

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.MedicalHistories.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<MedicalHistory, bool>>> GenrateCriteria(MedicalHistorySearchDTO inputModel)
        {
            List<Expression<Func<MedicalHistory, bool>>> criteria = [];

            if (inputModel.elementToken is not null)
                criteria.Add(x => x.medicalHistoryToken == inputModel.elementToken);

            if (inputModel.userPatientToken is not null)
                criteria.Add(x => x.userPatientToken == inputModel.userPatientToken);

            if (inputModel.fullCode is not null)
                criteria.Add(x => x.fullCode == inputModel.fullCode);

            return criteria;
        }

        public async Task<BaseActionDone<MedicalHistoryInfo>> AddOrUpdate(MedicalHistoryAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var medicalHistory = _mapper.Map<MedicalHistory>(inputModel);

            AddPatientMeasurement(medicalHistory);

            if (isUpdate)
                _unitOfWork.MedicalHistories.Update(medicalHistory);
            else
                await _unitOfWork.MedicalHistories.AddAsync(medicalHistory);

            var isDone = await _unitOfWork.CommitAsync();

            var medicalHistoryInfo = await _unitOfWork.MedicalHistories.FirstOrDefaultAsync(x => x.medicalHistoryToken == medicalHistory.medicalHistoryToken, MedicalHistoriesAdaptor.SelectExpressionMedicalHistoryInfo());

            return BaseActionDone<MedicalHistoryInfo>.GenrateBaseActionDone(isDone, medicalHistoryInfo);
        }

        private static void AddPatientMeasurement(MedicalHistory medicalHistory)
        {
            medicalHistory.patientSugarMeasurement = medicalHistory.patientSugarMeasurement.isMeasured ? medicalHistory.patientSugarMeasurement : null;

            medicalHistory.patientBloodPressureMeasurement = medicalHistory.patientBloodPressureMeasurement.isMeasured ? medicalHistory.patientBloodPressureMeasurement : null;

            medicalHistory.patientThyroidSensitivityMeasurement = medicalHistory.patientThyroidSensitivityMeasurement.isMeasured ?
                 medicalHistory.patientThyroidSensitivityMeasurement
                : null;
        }

        public async Task<BaseActionDone<MedicalHistoryInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var medicalHistory = await _unitOfWork.MedicalHistories.FirstOrDefaultAsync(x => x.medicalHistoryToken == inputModel.elementToken);

            _unitOfWork.MedicalHistories.Delete(medicalHistory);

            var isDone = await _unitOfWork.CommitAsync();

            return BaseActionDone<MedicalHistoryInfo>.GenrateBaseActionDone(isDone, MedicalHistoriesAdaptor.SelectExpressionMedicalHistoryInfo(medicalHistory));
        }

        #endregion Methods
    }
}