using App.Core.Models.General.BaseRequstModules;

namespace App.Core.Models.ClinicModules.NutritionalImprovementsModules.DTO
{
    public class NutritionalImprovementSearchDTO : BaseSearchDto
    {
        public Guid? userPatientToken { get; set; }
        public bool includeUserPatientInfoData { get; set; }
    }
}