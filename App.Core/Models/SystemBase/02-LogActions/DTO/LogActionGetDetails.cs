using App.Core.Models.General.BaseRequstModules;

namespace App.Core.Models.SystemBase._02_LogActions.DTO
{
    public class LogActionGetDetails : BaseGetDetailsDto
    {
        public ulong logActionId { get; set; }
    }
}