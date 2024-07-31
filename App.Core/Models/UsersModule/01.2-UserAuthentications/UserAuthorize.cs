using App.Core.Consts.Users;

namespace App.Core.Models.UsersModule._01._2_UserAuthentications
{
    public class UserAuthorize
    {
        public Guid userToken { get; set; }
        public Guid systemRoleToken { get; set; }
        public EnumUserType userType { get; set; }
    }
}