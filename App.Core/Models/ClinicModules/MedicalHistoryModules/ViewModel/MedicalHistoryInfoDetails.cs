using App.Core.Models.Users;

namespace App.Core.Models.ClinicModules.MedicalHistoriesModules.ViewModel
{
    public class MedicalHistoryInfoDetails : MedicalHistoryInfo
    {
        public UserInfo userPatientInfo { get; set; }
    }
}