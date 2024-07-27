using App.Core;
using App.Core.Interfaces.SystemBase.Operations;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.OperationsModules.DTO;
using App.Core.Models.ClinicModules.OperationsModules.ViewModel;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.General.PaginationModule;
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

        public async Task<BaseGetDataWithPagnation<OperationInfo>> GetAllAsync(OperationSearchDTO inputModel)
        {
            var select = OperationsAdaptor.SelectExpressionOperationInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Operations.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<Operation, bool>>> GenrateCriteria(OperationSearchDTO inputModel)
        {
            List<Expression<Func<Operation, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.operationName.Contains(inputModel.textSearch) ||
                x.userData.userName.Contains(inputModel.textSearch) ||
                x.userData.fullCode.Contains(inputModel.textSearch));
            }

            if (inputModel.elementToken is not null)
                criteria.Add(x => x.operationToken == inputModel.elementToken);

            if (inputModel.fullCode is not null)
                criteria.Add(x => x.fullCode == inputModel.fullCode);

            return criteria;
        }

        public async Task<OperationInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = OperationsAdaptor.SelectExpressionOperationDetails();

            Expression<Func<Operation, bool>> criteria = (x) => x.operationToken == inputModel.elementToken;

            List<Expression<Func<Operation, object>>> includes = [];

            includes.Add(x => x.userData);

            var operationInfo = await _unitOfWork.Operations.FirstOrDefaultAsync(criteria, select, includes);

            return operationInfo;
        }

        public async Task<BaseActionDone<OperationInfo>> AddOrUpdate(OperationAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var operation = _mapper.Map<Operation>(inputModel);

            if (isUpdate)
                _unitOfWork.Operations.Update(operation);
            else
                await _unitOfWork.Operations.AddAsync(operation);

            var isDone = await _unitOfWork.CommitAsync();

            var operationInfo = await _unitOfWork.Operations.FirstOrDefaultAsync(x => x.operationToken == operation.operationToken, OperationsAdaptor.SelectExpressionOperationInfo());

            return BaseActionDone<OperationInfo>.GenrateBaseActionDone(isDone, operationInfo);
        }

        public async Task<BaseActionDone<OperationInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var operation = await _unitOfWork.Operations.FirstOrDefaultAsync(x => x.operationToken == inputModel.elementToken);

            _unitOfWork.Operations.Delete(operation);

            var isDone = await _unitOfWork.CommitAsync();

            var operationInfo = await _unitOfWork.Operations.FirstOrDefaultAsync(x => x.operationToken == operation.operationToken, OperationsAdaptor.SelectExpressionOperationInfo());

            return BaseActionDone<OperationInfo>.GenrateBaseActionDone(isDone, operationInfo);
        }

        #endregion Methods
    }
}