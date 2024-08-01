using App.Core.Models.SystemBase.BaseClass;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.BaseEntitys
{
    public static class BaseEntitiesAdaptor
    {
        public static Expression<Func<BaseEntity, BaseEntityInfo>> SelectExpressionBaseEntityInfo()
        {
            return baseEntity => new BaseEntityInfo()
            {
                isDeleted = baseEntity.isDeleted ?? false,
                createdDateTime = GetDateTimeLocal(baseEntity.createdDate),
                updatedDateTime = GetDateTimeLocal(baseEntity.updatedDate.GetValueOrDefault()),
            };
        }

        public static BaseEntityInfo SelectExpressionBaseEntityInfo(BaseEntity baseEntity)
        {
            if (baseEntity == null)
                return null;

            return new BaseEntityInfo
            {
                isDeleted = baseEntity.isDeleted ?? false,
                createdDateTime = GetDateTimeLocal(baseEntity.createdDate),
                updatedDateTime = GetDateTimeLocal(baseEntity.updatedDate.GetValueOrDefault()),
            };
        }

        private static string GetDateTimeLocal(DateTimeOffset dateTimeOffset) => dateTimeOffset.ToLocalTime().DateTime.ToString("yyyy/MM/dd hh:mm:ss");
    }
}