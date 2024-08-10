using App.Core.Consts.SystemBase;

namespace App.Core.Models.SystemBase.BaseClass
{
    public class BaseEntityInfo
    {
        public string? fullCode { get; set; }
        public EnumEntityStatus activationType { get; set; }
        public string? createdDateTime { get; set; }
        public string? updatedDateTime { get; set; }
    }
}