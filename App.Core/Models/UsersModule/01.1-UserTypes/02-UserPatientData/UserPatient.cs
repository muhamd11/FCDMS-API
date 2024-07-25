using App.Core.Consts.SystemBase;
using App.Core.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData
{
    [Table($"{nameof(UserPatient)}s", Schema = nameof(EnumDatabaseSchema.Users))]
    public class UserPatient
    {
        [JsonIgnore, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid userPatientToken { get; set; }

        //relations
        [JsonIgnore, ForeignKey(nameof(User))]
        public Guid userToken { get; set; }
        
    }
}