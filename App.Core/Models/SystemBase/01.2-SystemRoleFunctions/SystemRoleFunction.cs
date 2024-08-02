using App.Core.Consts.SystemBase;
using App.Core.Models.SystemBase.BaseClass;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Core.Models.SystemBase._01._2_SystemRoleFunctions
{
    [Table($"{nameof(SystemRoleFunction)}s", Schema = nameof(EnumDatabaseSchema.SystemBase))]
    public class SystemRoleFunction : BaseEntity
    {
        [Key, JsonIgnore] public Guid systemRoleFunctionToken { get; set; }
        [JsonIgnore] public Guid systemRoleToken { get; set; }
        public EnumFunctionsType functionsType { get; set; }
        public string moduleId { get; set; }
        public string functionId { get; set; }
        public bool isHavePrivilege { get; set; }
    }
}