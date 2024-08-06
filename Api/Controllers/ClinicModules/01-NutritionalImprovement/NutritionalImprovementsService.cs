using App.Core;
using App.Core.Interfaces.SystemBase.NutritionalImprovements;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.DTO;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.ViewModel;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.General.PaginationModule;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.NutritionalImprovements
{
    internal class NutritionalImprovementService : INutritionalImprovementsServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public NutritionalImprovementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<NutritionalImprovementInfoDetails> GetDetails(NutritionalImprovementGetDetailsDTO inputModel)
        {
            var select = NutritionalImprovementsAdaptor.SelectExpressionNutritionalImprovementInfoDetails();

            Expression<Func<NutritionalImprovement, bool>> criteria = (x) => x.nutritionalImprovementToken == inputModel.elementToken;

            var nutritionalImprovementInfo = await _unitOfWork.NutritionalImprovements.FirstOrDefaultAsync(criteria, select);

            return nutritionalImprovementInfo;
        }

        public async Task<BaseGetDataWithPagnation<NutritionalImprovementInfo>> GetAllAsync(NutritionalImprovementSearchDTO inputModel)
        {
            var select = NutritionalImprovementsAdaptor.SelectExpressionNutritionalImprovementInfo(inputModel.includeUserPatientInfoData);

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.NutritionalImprovements.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<NutritionalImprovement, bool>>> GenrateCriteria(NutritionalImprovementSearchDTO inputModel)
        {
            List<Expression<Func<NutritionalImprovement, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
                criteria.Add(x => x.patientWeightInKg.ToString().Contains(inputModel.textSearch) || x.patientHeightInCm.ToString().Contains(inputModel.textSearch));

            if (inputModel.elementToken is not null)
                criteria.Add(x => x.nutritionalImprovementToken == inputModel.elementToken);

            if (inputModel.userPatientToken is not null)
                criteria.Add(x => x.userPatientToken == inputModel.userPatientToken);

            if (inputModel.fullCode is not null)
                criteria.Add(x => x.fullCode == inputModel.fullCode);

            return criteria;
        }

        public async Task<BaseActionDone<NutritionalImprovementInfo>> AddOrUpdate(NutritionalImprovementAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var nutritionalImprovement = _mapper.Map<NutritionalImprovement>(inputModel);

            nutritionalImprovement = SetFullCode(nutritionalImprovement);

            var patientAge = await _unitOfWork.UserPatients.AsQueryable().Where(x => x.userPatientToken == nutritionalImprovement.userPatientToken)
                                                                   .Select(x => x.userPatientAge)
                                                                   .FirstOrDefaultAsync();

            nutritionalImprovement.patientBmr = CalculateBmr(inputModel, patientAge);

            if (isUpdate)
                _unitOfWork.NutritionalImprovements.Update(nutritionalImprovement);
            else
                await _unitOfWork.NutritionalImprovements.AddAsync(nutritionalImprovement);

            var isDone = await _unitOfWork.CommitAsync();

            var nutritionalImprovementInfo = await _unitOfWork.NutritionalImprovements.FirstOrDefaultAsync(x => x.nutritionalImprovementToken == nutritionalImprovement.nutritionalImprovementToken, NutritionalImprovementsAdaptor.SelectExpressionNutritionalImprovementInfo());

            return BaseActionDone<NutritionalImprovementInfo>.GenrateBaseActionDone(isDone, nutritionalImprovementInfo);
        }
        private NutritionalImprovement SetFullCode(NutritionalImprovement nutritionalImprovement)
        {
            if (!string.IsNullOrEmpty(nutritionalImprovement.fullCode))
            {
                //operation.primaryFullCode = $"{operation.Op.ToString()}_{operation.fullCode}";
                return nutritionalImprovement;
            }
            else
            {
                var totalCounts = _unitOfWork.NutritionalImprovements.Count();
                //operation.primaryFullCode = $"{operation.userTypeToken.ToString()}_{1 + totalCounts}";
                nutritionalImprovement.fullCode = (1 + totalCounts).ToString();
                return nutritionalImprovement;
            }
        }

        private decimal CalculateBmr(NutritionalImprovementAddOrUpdateDTO inputModel, int patientAge)
        {
            //447.593 + (9.247 × weight in kg) + ( 3.098 × height in cm)−(4.330 × age in years)
            return 447.593m + (9.247m * inputModel.patientWeightInKg) + (3.098m * inputModel.patientHeightInCm) - (4.330m * patientAge);
        }

        public async Task<BaseActionDone<NutritionalImprovementInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var nutritionalImprovement = await _unitOfWork.NutritionalImprovements.FirstOrDefaultAsync(x => x.nutritionalImprovementToken == inputModel.elementToken);

            _unitOfWork.NutritionalImprovements.Delete(nutritionalImprovement);

            var isDone = await _unitOfWork.CommitAsync();

            return BaseActionDone<NutritionalImprovementInfo>.GenrateBaseActionDone(isDone, NutritionalImprovementsAdaptor.SelectExpressionNutritionalImprovementInfo(nutritionalImprovement));
        }

        #endregion Methods
    }
}