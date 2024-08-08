using App.Core.Consts.SystemBase;
using App.Core.Models.SystemBase.BaseClass;
using App.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models.ClinicModules.NutritionalImprovementsModules
{
    [Table($"{nameof(NutritionalImprovement)}s", Schema = nameof(EnumDatabaseSchema.ClinicManagement))]
    [Index(nameof(fullCode), IsUnique = true)]
    [Index(nameof(createdDate))]
    [Index(nameof(userPatientToken))]
    public class NutritionalImprovement : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid nutritionalImprovementToken { get; set; }

        public decimal patientHeightInCm { get; set; }

        public decimal patientWeightInKg { get; set; }

        public decimal patientBmr { get; set; }

        // Relations
        [ForeignKey(nameof(userPatientData))]
        public Guid userPatientToken { get; set; }

        public User userPatientData { get; set; }
    }
}