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
    [Index(nameof(userPatientToken))]
    public class Operation : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid operationToken { get; set; }

        public string operationName { get; set; }
        public DateTimeOffset operationDate { get; set; }

        [ForeignKey(nameof(userPatientData))]
        public Guid userPatientToken { get; set; }

        public User userPatientData { get; set; }
    }
}