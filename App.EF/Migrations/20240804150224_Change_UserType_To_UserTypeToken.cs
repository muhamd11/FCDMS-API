using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class Change_UserType_To_UserTypeToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "systemRoleUserType",
                schema: "SystemBase",
                table: "SystemRoles",
                newName: "systemRoleUserTypeToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "systemRoleUserTypeToken",
                schema: "SystemBase",
                table: "SystemRoles",
                newName: "systemRoleUserType");
        }
    }
}