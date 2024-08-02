using App.Core.Consts.SystemBase;
using App.Core.Models.SystemBase.BaseClass;
using App.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models.ClinicModules.MedicalHistoriesModules
{
    [Table("MedicalHistories", Schema = nameof(EnumDatabaseSchema.ClinicManagement))]
    [Index(nameof(fullCode), IsUnique = true)]
    [Index(nameof(userPatientToken))]
    public class MedicalHistory : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid medicalHistoryToken { get; set; }

        public BaseMeasurement? patientSugarMeasurement { get; set; }

        public BaseMeasurement? patientBloodPressureMeasurement { get; set; }

        public BaseMeasurement? patientThyroidSensitivityMeasurement { get; set; }


        [ForeignKey(nameof(userPatientData))]
        public Guid userPatientToken { get; set; }

        public User userPatientData { get; set; }
    }

    [Owned]
    public class BaseMeasurement
    {
        public bool isMeasured { get; set; }
        public double? measurementValue { get; set; }
        public DateOnly measurementDate { get; set; }
    }
}