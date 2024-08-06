using Newtonsoft.Json;

namespace App.Core.Models.SystemBase.BaseClass
{
    public class BaseEntity
    {
        public string? fullCode { get; set; }

        [JsonIgnore]
        public string? primaryFullCode { get; set; }

        public bool? isDeleted { get; set; }
        public DateTimeOffset createdDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? updatedDate { get; set; }
    }
}