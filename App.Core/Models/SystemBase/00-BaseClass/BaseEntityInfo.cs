namespace App.Core.Models.SystemBase.BaseClass
{
    public class BaseEntityInfo
    {
        public string? fullCode { get; set; }
        public bool? isDeleted { get; set; }
        public string? createdDateTime { get; set; }
        public string? updatedDateTime { get; set; }
    }
}