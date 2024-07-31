using App.Core.Models.Users;

namespace App.Core.Models.ClinicModules.VisitsModules
{
    public class VisitInfoDetails : VisitInfo
    {
        public UserInfo userPatientInfo { get; set; }
    }
}