using App.Core.Models.Users;

namespace App.Core.Models.UsersModule.LogActionsModel.ViewModel
{
    public class LogActionInfo
    {
        public Guid logActionToken { get; set; }
        public UserInfo logUser { get; set; }
        public string ModelName { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;
        public string actionType { get; set; }
    }
}