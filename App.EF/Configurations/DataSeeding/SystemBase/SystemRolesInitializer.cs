using App.Core.Consts.Users;
using App.Core.Models.SystemBase.Roles;

namespace App.EF.Configurations
{
    internal static class SystemRolesInitializer
    {
        public static List<SystemRole> GetSystemRoles() => new() {
          Developer,
          Doctor   ,
          Employee ,
          Patient  ,
        };

        private static SystemRole Developer = new()
        {
            fullCode = "1",
            systemRoleToken = Guid.Parse("AD792233-BA34-40F0-AFB6-ED4C742ABB1F"),
            systemRoleName = "صلاحيات مطور اساسية",
            systemRoleDescription = "مضافة من قبل النظام",
            systemRoleUserToken = EnumUserType.Developer,
            systemRoleCanUseDefault = true,
            createdDate = SharedInshlizer.creationDateTime,
        };

        private static SystemRole Doctor = new()
        {
            fullCode = "2",
            systemRoleToken = Guid.Parse("F0A30312-33AD-4969-B904-CB2EDFDACCC6"),
            systemRoleName = "صلاحيات دكتور اساسية",
            systemRoleDescription = "مضافة من قبل النظام",
            systemRoleUserToken = EnumUserType.Doctor,
            systemRoleCanUseDefault = true,
            createdDate = SharedInshlizer.creationDateTime,
        };

        private static SystemRole Employee = new()
        {
            fullCode = "3",
            systemRoleToken = Guid.Parse("1B14E306-A0CD-4334-A30D-3F4D92B5AE68"),
            systemRoleName = "صلاحيات موظف اساسية",
            systemRoleDescription = "مضافة من قبل النظام",
            systemRoleUserToken = EnumUserType.Employee,
            systemRoleCanUseDefault = true,
            createdDate = SharedInshlizer.creationDateTime,
        };

        private static SystemRole Patient = new()
        {
            fullCode = "4",
            systemRoleToken = Guid.Parse("2B979B0D-66D7-4B2D-B048-E448C902B1FE"),
            systemRoleName = "صلاحيات مريض اساسية",
            systemRoleDescription = "مضافة من قبل النظام",
            systemRoleUserToken = EnumUserType.Patient,
            systemRoleCanUseDefault = true,
            createdDate = SharedInshlizer.creationDateTime,
        };
    }
}