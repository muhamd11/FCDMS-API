using App.Core.Consts.Users;
using App.Core.Models.General.BaseRequstModules;

namespace App.Core.Models.Users
{
    public class UserSearchDto : BaseSearchDto
    {
        public EnumUserType? userTypeToken { get; set; }
    }
}