using Api.Controllers.SystemBase.BaseEntitys;
using Api.Controllers.UsersModule.Users;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.OperationsModules.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.Operations
{
    public static class OperationsAdaptor
    {
        public static Expression<Func<Operation, OperationInfo>> SelectExpressionOperationInfo(bool includeUserPatientInfoData = false)
        {
            return operation => new OperationInfo
            {
                operationToken = operation.operationToken,
                operationName = operation.operationName,
                operationDate = operation.operationDate,
                userPatientInfo = includeUserPatientInfoData == false ? null : UsersAdaptor.SelectExpressionUserInfo(operation.userPatientData),
                fullCode = operation.fullCode,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).isDeleted,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).createdDateTime,
            };
        }

        public static Expression<Func<Operation, OperationInfoDetails>> SelectExpressionOperationInfoDetails()
        {
            return operation => new OperationInfoDetails
            {
                operationToken = operation.operationToken,
                operationName = operation.operationName,
                operationDate = operation.operationDate,
                fullCode = operation.fullCode,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).isDeleted,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).createdDateTime,
                userPatientInfo = UsersAdaptor.SelectExpressionUserInfo(operation.userPatientData)
            };
        }

        public static OperationInfo SelectExpressionOperationInfo(Operation operation)
        {
            if (operation == null)
                return null;

            return new OperationInfo
            {
                operationToken = operation.operationToken,
                operationName = operation.operationName,
                operationDate = operation.operationDate,
                fullCode = operation.fullCode,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).isDeleted,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).createdDateTime
            };
        }

        public static OperationInfoDetails SelectExpressionOperationInfoDetails(Operation operation)
        {
            if (operation == null)
                return null;

            return new OperationInfoDetails
            {
                operationToken = operation.operationToken,
                operationName = operation.operationName,
                operationDate = operation.operationDate,
                fullCode = operation.fullCode,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).isDeleted,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(operation).createdDateTime,
                //userPatientInfoDetails =  UsersAdaptor.SelectExpressionUserInfoDetails(operation.userPatientData) 
            };
        }
    }
}