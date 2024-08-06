using System.Text.Json.Serialization;

namespace App.Core.Models.SystemBase.BaseClass
{
    public class BaseEntityInfo
    {
        [JsonPropertyOrder(0)]
        public string fullCode { get; set; }

        [JsonPropertyOrder(1)]
        public bool isDeleted { get; set; }

        [JsonPropertyOrder(2)]
        public string createdDateTime { get; set; }

        [JsonPropertyOrder(3)]
        public string updatedDateTime { get; set; }
    }
}