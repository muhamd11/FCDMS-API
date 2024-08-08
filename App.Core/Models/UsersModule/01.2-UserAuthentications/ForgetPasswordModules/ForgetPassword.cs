using App.Core.Consts.SystemBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules
{
    [Table($"{nameof(ForgetPassword)}s", Schema = nameof(EnumDatabaseSchema.Users))]
    public class ForgetPassword
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid forgetPasswordToken { get; set; }
        public Guid userToken { get; set; }
        public int userOtp { get; set; }
        public DateTime expireDate { get; set; }
    }
}