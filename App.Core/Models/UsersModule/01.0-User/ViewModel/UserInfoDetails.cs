using App.Core.Models.Buyers;
using App.Core.Models.SystemBase.Roles.ViewModel;
using App.Core.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;

namespace App.Core.Models.Users
{
    public class UserInfoDetails : UserInfo
    {
        public SystemRoleInfo roleData { get; set; }
        public UserProfile userProfile { get; set; }
        public UserPatientInfo userPatientInfo { get; set; }
    }
}