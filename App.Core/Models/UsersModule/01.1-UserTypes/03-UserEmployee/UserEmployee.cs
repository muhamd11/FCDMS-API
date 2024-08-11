using App.Core.Consts.GeneralModels;
using App.Core.Consts.SystemBase;
using App.Core.Models.Users;
using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee
{
    [Table($"{nameof(UserEmployee)}s", Schema = nameof(EnumDatabaseSchema.Users))]
    public class UserEmployee
    {
        [JsonIgnore, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid userEmployeeToken { get; set; }

        //relations
        [JsonIgnore, ForeignKey(nameof(userData))]
        public Guid? userToken { get; set; }

        [JsonIgnore]
        public User userData { get; set; }

        public EnumGenderType userGender { get; set; }

        public string userNationality { get; set; }
        
        public string userNationalId { get; set; }
    }
}