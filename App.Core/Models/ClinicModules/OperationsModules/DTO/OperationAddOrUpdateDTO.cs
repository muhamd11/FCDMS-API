namespace App.Core.Models.ClinicModules.OperationsModules.DTO
{
    public class OperationAddOrUpdateDTO
    {
        public Guid operationToken { get; set; }
        public string operationName { get; set; }
        public DateTimeOffset operationDate { get; set; }
        public Guid userToken { get; set; }
        public string fullCode { get; set; }
    }
}