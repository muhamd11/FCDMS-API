using App.Core.Consts.SystemBase;
using App.Core.Models.SystemBase.BaseClass;
using App.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models.ClinicModules.OperationsModules
{
    [Table($"{nameof(Operation)}s", Schema = nameof(EnumDatabaseSchema.ClinicManagement))]
    [Index(nameof(fullCode), IsUnique = true)]
    [Index(nameof(operationName))]
    [Index(nameof(operationDate))]
    [Index(nameof(userToken))]
    public class Operation : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid operationToken { get; set; }

        public string operationName { get; set; }
        public DateTimeOffset operationDate { get; set; }

        [ForeignKey(nameof(userData))]
        public Guid userToken { get; set; }

        public User userData { get; set; }

        //TODO: Add Clinic Token And Clinic Class
    }
}