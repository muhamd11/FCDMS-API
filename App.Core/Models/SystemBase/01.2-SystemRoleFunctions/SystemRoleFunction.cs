using App.Core.Consts.SystemBase;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models.SystemBase._01._2_SystemRoleFunctions
{
    [Table($"{nameof(SystemRoleFunction)}s", Schema = nameof(EnumDatabaseSchema.SystemBase))]
    public class SystemRoleFunction
    {
        [Key, JsonIgnore] public Guid systemRoleFunctionToken { get; set; }
        [JsonIgnore] public Guid systemRoleToken { get; set; }
        public string functionText { get; set; }
        public EnumFunctionsType functionsType { get; set; }
        public string? customizeFunctionId { get; set; }
        public string moduleId { get; set; }
        public string functionId { get; set; }
        public bool isHavePrivilege { get; set; }
    }
}