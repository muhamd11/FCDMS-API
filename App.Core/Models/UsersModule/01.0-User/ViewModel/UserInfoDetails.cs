using App.Core.Consts.Users;
using App.Core.Models.SystemBase.Roles.ViewModel;
using App.Core.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;
using App.Core.Models.UsersModule._01_1_UserTypes;
using System.Text.Json.Serialization;

namespace App.Core.Models.Users
{
    public class UserInfoDetails : IUserInfo
    {
        public Guid? userToken { get; set; }
        public string? userName { get; set; }
        public string? userEmail { get; set; }
        public string? userPhone { get; set; }
        public string? userLoginName { get; set; }
        public EnumUserType? userTypeToken { get; set; }
        public string? fullCode { get; set; }
        public bool? isDeleted { get; set; }
        public string? createdDateTime { get; set; }
        public string? updatedDateTime { get; set; }
        public UserProfile? userProfileData { get; set; }

        public UserPatientInfo? userPatientInfoData { get; set; }

        public SystemRoleInfo? roleData { get; set; }
    }
}