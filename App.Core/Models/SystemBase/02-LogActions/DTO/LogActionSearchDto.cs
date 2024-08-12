using App.Core.Models.General.BaseRequstModules;

namespace App.Core.Models.SystemBase.LogActions.DTO
{
    public class LogActionSearchDto : BaseSearchDto
    {
        public ulong logActionId { get; set; }
        public Guid? userToken { get; set; }
        public bool includeUserInfoData { get; set; }
    }
}