using App.Core.Consts.SystemBase;
using App.Core.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor
{
    [Table($"{nameof(UserDoctor)}s", Schema = nameof(EnumDatabaseSchema.Users))]
    public class UserDoctor
    {
        [JsonIgnore, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid userDoctorToken { get; set; }

        //relations
        [JsonIgnore, ForeignKey(nameof(userData))]
        public Guid userToken { get; set; }

        [JsonIgnore]
        public User userData { get; set; }
    }
}