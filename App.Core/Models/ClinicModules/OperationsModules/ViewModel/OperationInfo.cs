using App.Core.Models.SystemBase.BaseClass;

namespace App.Core.Models.ClinicModules.OperationsModules.ViewModel
{
    public class OperationInfo : BaseEntityInfo
    {
        public Guid operationToken { get; set; }
        public string operationName { get; set; }
        public DateTimeOffset operationDate { get; set; }
    }
}