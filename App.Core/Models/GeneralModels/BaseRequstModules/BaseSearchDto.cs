using App.Core.Consts.SystemBase;
using App.Core.Models.General.PaginationModule;

namespace App.Core.Models.General.BaseRequstModules
{
    public class BaseSearchDto : PaginationRequest
    {
        public Guid? elementToken { get; set; }
        public string? textSearch { get; set; }
        public string? fullCode { get; set; }
        public EnumActivationType? activationType { get; set; }
    }
}