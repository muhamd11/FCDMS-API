using System.Text.Json.Serialization;

namespace App.Core.Models.UsersModule.LogActionsModel.ViewModel
{
    public class LogActionInfoDetails : LogActionInfo
    {
        [JsonPropertyOrder(6)]
        public string oldActionData { get; set; }

        [JsonPropertyOrder(7)]
        public string newActionData { get; set; }
    }
}