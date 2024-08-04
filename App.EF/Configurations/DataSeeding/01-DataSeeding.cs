using App.Core.Models.SystemBase.Roles;
using App.Core.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace App.EF.Configurations
{
    internal class DataSeeding
    {
        public void Configure(ModelBuilder modelBuilder)
        {

            //user
            modelBuilder.Entity<SystemRole>().HasData(SystemRolesInitializer.GetSystemRoles());
            modelBuilder.Entity<User>().HasData(UserInitializer.GetUsers());
        }
    }
}