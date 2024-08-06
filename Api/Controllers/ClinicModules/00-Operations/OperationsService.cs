﻿using App.Core;
using App.Core.Interfaces.SystemBase.Operations;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.OperationsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.General.PaginationModule;
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
            operation = SetFullCode(operation, isUpdate);
            if (isUpdate)
                _unitOfWork.Operations.Update(operation);
            else
                await _unitOfWork.Operations.AddAsync(operation);

            var isDone = await _unitOfWork.CommitAsync();

            var operationInfo = await _unitOfWork.Operations.FirstOrDefaultAsync(x => x.operationToken == operation.operationToken, OperationsAdaptor.SelectExpressionOperationInfo());

            return BaseActionDone<OperationInfo>.GenrateBaseActionDone(isDone, operationInfo);
        }

        private Operation SetFullCode(Operation operation, bool isUpdate)
        {
            if (!string.IsNullOrEmpty(operation.fullCode))
            {
                //operation.primaryFullCode = $"{operation.Op.ToString()}_{operation.fullCode}";
                return operation;
            }
            else
            {
                var totalCounts = _unitOfWork.Operations.Count();
                //operation.primaryFullCode = $"{operation.userTypeToken.ToString()}_{1 + totalCounts}";
                operation.fullCode = isUpdate ? totalCounts.ToString() : (1 + totalCounts).ToString();
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