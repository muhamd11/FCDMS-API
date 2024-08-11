using App.Core;
using App.Core.Consts.SystemBase;
using App.Core.Interfaces.SystemBase.Operations;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.OperationsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.General.PaginationModule;
using App.Core.Models.GeneralModels.BaseRequstModules;
using App.Core.Models.Users;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.Operations
{
    internal class OperationService : IOperationsServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public OperationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<OperationInfoDetails> GetDetails(OperationGetDetailsDTO inputModel)
        {
            var select = OperationsAdaptor.SelectExpressionOperationInfoDetails();

            Expression<Func<Operation, bool>> criteria = (x) => x.operationToken == inputModel.elementToken;

            var operationInfo = await _unitOfWork.Operations.FirstOrDefaultAsync(criteria, select);

            return operationInfo;
        }

        public async Task<BaseGetDataWithPagnation<OperationInfo>> GetAllAsync(OperationSearchDTO inputModel)
        {
            var select = OperationsAdaptor.SelectExpressionOperationInfo(inputModel.includeUserPatientInfoData);

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Operations.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<Operation, bool>>> GenrateCriteria(OperationSearchDTO inputModel)
        {
            List<Expression<Func<Operation, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
                criteria.Add(x => x.operationName.Contains(inputModel.textSearch));

            if (inputModel.activationType is not null)
                criteria.Add(x => x.activationType == inputModel.activationType);

            if (inputModel.elementToken is not null)
                criteria.Add(x => x.operationToken == inputModel.elementToken);

            if (inputModel.userPatientToken is not null)
                criteria.Add(x => x.userPatientToken == inputModel.userPatientToken);

            if (inputModel.fullCode is not null)
                criteria.Add(x => x.fullCode == inputModel.fullCode);

            return criteria;
        }

        public async Task<BaseActionDone<OperationInfo>> AddOrUpdate(OperationAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var operation = _mapper.Map<Operation>(inputModel);
            operation = SetFullCode(operation);
            operation.activationType = operation.activationType == 0 ? EnumActivationType.active : operation.activationType;

            if (isUpdate)
                _unitOfWork.Operations.Update(operation);
            else
                await _unitOfWork.Operations.AddAsync(operation);

            var isDone = await _unitOfWork.CommitAsync();

            var operationInfo = await _unitOfWork.Operations.FirstOrDefaultAsync(x => x.operationToken == operation.operationToken, OperationsAdaptor.SelectExpressionOperationInfo());

            return BaseActionDone<OperationInfo>.GenrateBaseActionDone(isDone, operationInfo);
        }

        public async Task<BaseActionDone<OperationInfo>> ChangeOperationActivationType(BaseChangeActivationDto inputModel)
        {
            var operation = await _unitOfWork.Operations.FirstOrDefaultAsync(x => x.operationToken == inputModel.elementToken);

            OperationAddOrUpdateDTO operationAddOrUpdateDTO = new()
            {
                operationToken = operation.operationToken,
                operationName = operation.operationName,
                operationDate = operation.operationDate,
                userPatientToken = operation.userPatientToken,
                fullCode = operation.fullCode,

                // Update operation Activation Type
                activationType = inputModel.activationType
            };

            return await AddOrUpdate(operationAddOrUpdateDTO, true);
        }

        private Operation SetFullCode(Operation operation)
        {
            if (!string.IsNullOrEmpty(operation.fullCode))
                return operation;
            else
            {
                var totalCounts = _unitOfWork.Operations.Count();
                operation.fullCode = (1 + totalCounts).ToString();
                return operation;
            }
        }

        public async Task<BaseActionDone<OperationInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var operation = await _unitOfWork.Operations.FirstOrDefaultAsync(x => x.operationToken == inputModel.elementToken);

            _unitOfWork.Operations.Delete(operation);

            var isDone = await _unitOfWork.CommitAsync();

            return BaseActionDone<OperationInfo>.GenrateBaseActionDone(isDone, OperationsAdaptor.SelectExpressionOperationInfo(operation));
        }

        #endregion Methods
    }
}