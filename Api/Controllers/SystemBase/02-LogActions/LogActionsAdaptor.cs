using Api.Controllers.UsersModule.Users;
using App.Core.Models.SystemBase.LogActions;
using App.Core.Models.SystemBase.LogActions.ViewModel;

using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.LogActions
{
    public static class LogActionsAdaptor
    {
        public static Expression<Func<LogAction, LogActionInfo>> SelectExpressionLogActionInfo(bool includeUserInfoData = false)
        {
            return logAction => new LogActionInfo
            {
                logActionId = logAction.logActionId,
                modelName = logAction.modelName,
                actionDate = logAction.actionDate,
                actionType = logAction.actionType,
                userInfoData = includeUserInfoData == false ? null : UsersAdaptor.SelectExpressionUserInfo(logAction.userData),
                newActionData = logAction.newActionData,
                oldActionData = logAction.oldActionData
            };
        }

        public static Expression<Func<LogAction, LogActionInfoDetails>> SelectExpressionLogActionDetails()
        {
            return logAction => new LogActionInfoDetails
            {
                logActionId = logAction.logActionId,
                modelName = logAction.modelName,
                actionDate = logAction.actionDate,
                actionType = logAction.actionType,
                newActionData = logAction.newActionData,
                oldActionData = logAction.oldActionData
            };
        }

        public static LogActionInfo SelectExpressionLogActionInfo(LogAction logAction)
        {
            if (logAction == null)
                return null;

            return new LogActionInfo
            {
                logActionId = logAction.logActionId,
                modelName = logAction.modelName,
                actionDate = logAction.actionDate,
                actionType = logAction.actionType,
                newActionData = logAction.newActionData,
                oldActionData = logAction.oldActionData
            };
        }

        public static LogActionInfoDetails SelectExpressionLogActionDetails(LogAction logAction)
        {
            if (logAction == null)
                return null;

            return new LogActionInfoDetails
            {
                logActionId = logAction.logActionId,
                modelName = logAction.modelName,
                actionDate = logAction.actionDate,
                actionType = logAction.actionType,
                newActionData = logAction.newActionData,
                oldActionData = logAction.oldActionData
            };
        }
    }
}