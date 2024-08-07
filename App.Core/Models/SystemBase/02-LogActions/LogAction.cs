using App.Core.Consts.SystemBase;
using App.Core.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models.SystemBase.LogActions

{
    [Table($"{nameof(LogAction)}s", Schema = nameof(EnumDatabaseSchema.SystemBase))]
    public class LogAction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong logActionId { get; set; }

        [ForeignKey(nameof(userData))]
        public Guid? userToken { get; set; }

        public User? userData { get; set; }

        public string modelName { get; set; }
        public DateTimeOffset actionDate { get; set; }
        public string actionType { get; set; }
        public string? oldActionData { get; set; }
        public string? newActionData { get; set; }
    }
}