using App.Core.Consts.SystemBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules
{
    [Table($"{nameof(OtpRecord)}s", Schema = nameof(EnumDatabaseSchema.Users))]
    public class OtpRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OtpToken { get; set; }

        public Guid userToken { get; set; }
        public int userOtp { get; set; }
        public DateTime expireDate { get; set; }
    }
}