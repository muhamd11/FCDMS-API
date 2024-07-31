using App.Core.Models.General.BaseRequstModules;

namespace App.Core.Models.ClinicModules.VisitsModules.DTO
{
    public class VisitSearchDTO : BaseSearchDto
    {
        public Guid? userPatientToken { get; set; }
        public bool includeUserPatientInfoData { get; set; }
    }
}