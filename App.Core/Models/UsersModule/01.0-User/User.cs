using App.Core.Consts.SystemBase;
using App.Core.Consts.Users;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.SystemBase.BaseClass;
using App.Core.Models.SystemBase.Roles;
using App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor;
using App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee;
using App.Core.Models.UsersModule._01_1_UserTypes;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Core.Models.Users
{
    [Table($"{nameof(User)}s", Schema = nameof(EnumDatabaseSchema.Users))]
    [Index(nameof(userType))]
    [Index(nameof(fullCode), IsUnique = true)]
    [Index(nameof(userEmail), IsUnique = true)]
    [Index(nameof(userPhone), IsUnique = true)]
    [Index(nameof(userLoginName), IsUnique = true)]
    public class User : BaseEntity
    {
        public User()
        {
            operationsData = new HashSet<Operation>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid userToken { get; set; }

        public string userName { get; set; }
        public string? userEmail { get; set; }
        public string? userPhone { get; set; }
        public string? userPhoneDialCode { get; set; }
        public string? userPhoneCC { get; set; }
        public string? userPhoneCCName { get; set; }
        public string? userLoginName { get; set; }
        public string userPassword { get; set; }
        public EnumUserType userType { get; set; }

        //relations
        [ForeignKey(nameof(roleData))]
        public Guid systemRoleToken { get; set; }

        public SystemRole roleData { get; set; }

        [JsonIgnore]
        public ICollection<Operation> operationsData { get; set; }

        //using any user type
        public UserProfile? userProfileData { get; set; }

        public UserPatient? userPatientData { get; set; }
        public UserEmployee? userEmployeeData { get; set; }
        public UserDoctor? userDoctorData { get; set; }
    }
}