using App.Core.Consts.SystemBase;
using App.Core.Consts.Users;
using App.Core.Models.SystemBase.BaseClass;
using App.Core.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models.SystemBase.Roles
{
    [Table($"{nameof(SystemRole)}s", Schema = nameof(EnumDatabaseSchema.SystemBase))]
    public class SystemRole : BaseEntity
    {
        public SystemRole()
        {
            usersData = new HashSet<User>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid systemRoleToken { get; set; }

        public string systemRoleName { get; set; }
        public string systemRoleDescription { get; set; }
        public EnumUserType systemRoleUserToken { get; set; }
        public bool systemRoleCanUseDefault { get; set; }
        public ICollection<User> usersData { get; set; }
    }
}