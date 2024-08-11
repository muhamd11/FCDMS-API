using App.Core.Consts.SystemBase;
using Newtonsoft.Json;

namespace App.Core.Models.ClinicModules.MedicalHistoriesModules.DTO
{
    public class MedicalHistoryAddOrUpdateDTO
    {
        public Guid medicalHistoryToken { get; set; }

        public BaseMeasurement? patientSugarMeasurement { get; set; }

        public BaseMeasurement? patientBloodPressureMeasurement { get; set; }

        public BaseMeasurement? patientThyroidSensitivityMeasurement { get; set; }

        public Guid userPatientToken { get; set; }

        public string? fullCode { get; set; }

        [JsonIgnore]
        public EnumActivationType activationType { get; set; }
    }
}