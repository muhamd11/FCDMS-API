using App.Core.Consts.Users;
using App.Core.Helper;
using App.Core.Models.Users;

namespace App.EF.Configurations
{
    internal class UserInitializer
    {
        public static List<User> GetUsers() => new() {
          Developer,
        };

        private static User Developer = new()
        {
            fullCode = "1",
            primaryFullCode = $"{EnumUserType.Developer.ToString()}_1",
            userToken = Guid.Parse("ADE938F3-6406-4D09-A806-AB02E28C6902"),
            userName = "مدير النظام",
            userLoginName = "admin",
            userPassword = MethodsClass.Encrypt_Base64("0000"),
            systemRoleToken = Guid.Parse("AD792233-BA34-40F0-AFB6-ED4C742ABB1F"),
            userTypeToken = EnumUserType.Developer,
            createdDate = SharedInshlizer.creationDateTime,
        };
    }
}