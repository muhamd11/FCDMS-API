using App.Core.Models.Users;

namespace App.Core.Models.ClinicModules.OperationsModules.ViewModel
{
    public class OperationInfoDetails : OperationInfo
    {
        public UserInfo userInfoData { get; set; }
    }
}