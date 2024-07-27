using App.Core.Models.SystemBase.Roles.ViewModel;
using App.Core.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;
using App.Core.Models.UsersModule._01_1_UserTypes;

namespace App.Core.Models.Users
{
    public class UserInfoDetails : UserInfo
    {
        public SystemRoleInfo roleData { get; set; }
        public UserProfile userProfileData { get; set; }
        public UserPatientInfo userPatientInfoData { get; set; }
    }
}