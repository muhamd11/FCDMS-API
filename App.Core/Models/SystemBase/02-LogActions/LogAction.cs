using App.Core.Consts.SystemBase;
using App.Core.Models.SystemBase.BaseClass;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models.UsersModule.LogActionsModel

{
    [Table($"{nameof(LogAction)}s", Schema = nameof(EnumDatabaseSchema.SystemBase))]
    public class LogAction 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid logActionToken { get; set; }

        public Guid userToken { get; set; } // Changed to string to store user identifier
        public string modelName { get; set; }
        public DateTimeOffset actionDate { get; set; } = DateTime.UtcNow;
        public string actionType { get; set; }
        public string? oldData { get; set; }
        public string? newData { get; set; }
    }
}