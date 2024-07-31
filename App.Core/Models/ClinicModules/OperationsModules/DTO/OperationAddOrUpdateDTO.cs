using App.Core.Models.GeneralModels.BaseRequestHeaderModules;

namespace App.Core.Models.ClinicModules.OperationsModules.DTO
{
    public class OperationAddOrUpdateDTO 
    {
        public Guid operationToken { get; set; }
        public string operationName { get; set; }
        public DateTimeOffset operationDate { get; set; }
        public Guid userPatientToken { get; set; }
        public string fullCode { get; set; }
    }
}