using App.Core.Consts.SystemBase;
using App.Core.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Core.Models.UsersModule._01_1_UserTypes
{
    [Table($"{nameof(UserProfile)}s", Schema = nameof(EnumDatabaseSchema.Users))]
    public class UserProfile
    {
        [JsonIgnore, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid userProfileToken { get; set; }

        //phone-4
        public string userPhone2 { get; set; }

        public string userPhoneCC2 { get; set; }
        public string userPhoneCCName2 { get; set; }

        //phone-4
        public string userPhone3 { get; set; }

        public string userPhoneCC3 { get; set; }
        public string userPhoneCCName3 { get; set; }

        //phone-4
        public string userPhone4 { get; set; }

        public string userPhoneCC4 { get; set; }
        public string userPhoneCCName4 { get; set; }

        public string userContactEmail { get; set; }
        public DateOnly userBirthDate { get; set; }

        //relations
        [JsonIgnore, ForeignKey(nameof(userData))]
        public Guid? userToken { get; set; }

        [JsonIgnore]
        public User userData { get; set; }
    }
}