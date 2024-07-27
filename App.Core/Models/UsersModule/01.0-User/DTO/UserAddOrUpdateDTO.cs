using App.Core.Consts.Users;
using App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor;
using App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee;
using App.Core.Models.UsersModule._01_1_UserTypes;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;

namespace App.Core.Models.Users
{
    public class UserAddOrUpdateDTO
    {
        public Guid userToken { get; set; }
        public string? fullCode { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPhone { get; set; }
        public string userPhoneCC { get; set; }
        public string userPhoneCCName { get; set; }
        public string userLoginName { get; set; }
        public string userPassword { get; set; }
        public EnumUserType userType { get; set; }

        public Guid systemRoleToken { get; set; }
        public UserProfile userProfileData { get; set; } = new();
        public UserPatient userPatientData { get; set; } = new();
        public UserEmployee userEmployeeData { get; set; } = new();
        public UserDoctor userDoctorData { get; set; } = new();
    }
}