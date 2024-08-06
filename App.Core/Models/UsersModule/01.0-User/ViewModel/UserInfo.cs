using App.Core.Consts.Users;
using App.Core.Models.SystemBase.BaseClass;
using System.Text.Json.Serialization;

namespace App.Core.Models.Users
{
    public class UserInfo : BaseEntityInfo
    {
        [JsonPropertyOrder(-6)]
        public Guid userToken { get; set; }

        [JsonPropertyOrder(-5)]
        public string userName { get; set; }

        [JsonPropertyOrder(-4)]
        public string userEmail { get; set; }

        [JsonPropertyOrder(-3)]
        public string userPhone { get; set; }

        [JsonPropertyOrder(-2)]
        public string userLoginName { get; set; }

        [JsonPropertyOrder(-1)]
        public EnumUserType userTypeToken { get; set; }
    }
}