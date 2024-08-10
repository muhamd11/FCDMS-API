using App.Core.Consts.SystemBase;
using App.Core.Consts.Users;

namespace App.Core.Models.Users
{
    public class UserInfo : IUserInfo
    {
        public Guid? userToken { get; set; }
        public string? userName { get; set; }
        public string? userEmail { get; set; }
        public string? userPhone { get; set; }
        public string? userLoginName { get; set; }
        public EnumUserType? userTypeToken { get; set; }
        public string? fullCode { get; set; }
        public EnumEntityStatus? activationType { get; set; }
        public string? createdDateTime { get; set; }
        public string? updatedDateTime { get; set; }
    }

    public interface IUserInfo
    {
        public Guid? userToken { get; set; }
        public string? userName { get; set; }
        public string? userEmail { get; set; }
        public string? userPhone { get; set; }
        public string? userLoginName { get; set; }
        public EnumUserType? userTypeToken { get; set; }
        public string? fullCode { get; set; }
        public EnumEntityStatus? activationType { get; set; }
        public string? createdDateTime { get; set; }
        public string? updatedDateTime { get; set; }
    }
}