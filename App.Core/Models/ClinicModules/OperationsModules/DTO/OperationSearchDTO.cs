using App.Core.Models.General.BaseRequstModules;

namespace App.Core.Models.ClinicModules.OperationsModules.DTO
{
    public class OperationSearchDTO : BaseSearchDto
    {
        public Guid userPatientToken { get; set; }
        public bool includeUserPatientInfoData { get; set; }
    }
}