using App.Core.Models.SystemBase.BaseClass;
using App.Core.Models.Users;

namespace App.Core.Models.ClinicModules.MedicalHistoriesModules.ViewModel
{
    public class MedicalHistoryInfo : BaseEntityInfo
    {
        public Guid medicalHistoryToken { get; set; }

        public BaseMeasurement? patientSugarMeasurement { get; set; }

        public BaseMeasurement? patientBloodPressureMeasurement { get; set; }

        public BaseMeasurement? patientThyroidSensitivityMeasurement { get; set; }

        public UserInfo? userPatientInfo { get; set; }
    }
}