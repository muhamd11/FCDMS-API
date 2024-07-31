using App.Core.Models.General.BaseRequstModules;

namespace App.Core.Models.ClinicModules.MedicalHistoriesModules.DTO
{
    public class MedicalHistorySearchDTO : BaseSearchDto
    {
        public Guid? userPatientToken { get; set; }
        public bool includeUserPatientInfoData { get; set; }
    }
}