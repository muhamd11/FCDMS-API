namespace App.Core.Models.UsersModule.LogActionsModel.DTO
{
    public class LogActionAddOrUpdateDTO
    {
        public Guid logActionToken { get; set; }
        public Guid userToken { get; set; }
        public string modelName { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;
        public string actionType { get; set; }
        public string oldActionData { get; set; }
        public string newActionData { get; set; }
    }
}