using App.Core.Consts.GeneralModels;
using App.Core.Consts.SystemBase;
using App.Core.Models.SystemBase.BaseClass;
using App.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models.ClinicModules.VisitsModules
{
    [Table($"{nameof(Visit)}s", Schema = nameof(EnumDatabaseSchema.ClinicManagement))]
    [Index(nameof(fullCode), IsUnique = true)]
    [Index(nameof(userPatientToken))]
    public class Visit : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid visitToken { get; set; }

        public DateOnly expectedDateOfBirth { get; set; }

        public DateTimeOffset visitDate { get; set; }

        public string? userPatientComplaining { get; set; }

        public string? medications { get; set; }

        public string? generalNotes { get; set; }

        public FetalInformation? fetalInformations { get; set; }

        // Relations
        [ForeignKey(nameof(userPatientData))]
        public Guid userPatientToken { get; set; }

        public User userPatientData { get; set; }
    }

    [Owned]
    public class FetalInformation
    {
        public decimal fetalHeartBeatPerMinute { get; set; }
        public decimal fetalAgeInWeeks { get; set; }
        public decimal fetalAgeInMonths { get; set; }
        public decimal fetalWeightInKg { get; set; }
        public EnumGenderType fetalGender { get; set; }
    }
}