using App.Core.Models.SystemBase.BaseClass;
using App.Core.Models.Users;

namespace App.Core.Models.ClinicModules.VisitsModules
{
    public class OperationInfo : BaseEntityInfo
    {
        public Guid operationToken { get; set; }
        public string? operationName { get; set; }
        public UserInfo? userPatientInfo { get; set; }
        public DateTimeOffset operationDate { get; set; }
    }
}