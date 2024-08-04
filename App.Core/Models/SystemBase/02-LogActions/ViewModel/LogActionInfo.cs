
using App.Core.Models.Users;

namespace App.Core.Models.SystemBase.LogActions.ViewModel
{
    public class LogActionInfo
    {
        public Guid logActionToken { get; set; }
        public string modelName { get; set; }
        public DateTimeOffset actionDate { get; set; }
        public string actionType { get; set; }
        public UserInfo userInfoData { get; set; }
        public string oldActionData { get; set; }
        public string newActionData { get; set; }
    }
}