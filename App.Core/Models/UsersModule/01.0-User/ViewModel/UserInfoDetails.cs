using App.Core.Models.SystemBase.Roles.ViewModel;
using App.Core.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;
using App.Core.Models.UsersModule._01_1_UserTypes;
using System.Text.Json.Serialization;

namespace App.Core.Models.Users
{
    public class UserInfoDetails : UserInfo
    {
        [JsonPropertyOrder(4)]
        public UserProfile? userProfileData { get; set; }

        [JsonPropertyOrder(5)]
        public UserPatientInfo? userPatientInfoData { get; set; }

        [JsonPropertyOrder(6)]
        public SystemRoleInfo? roleData { get; set; }
    }
}