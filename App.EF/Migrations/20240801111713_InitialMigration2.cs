using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SystemRoles_systemRoleToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "systemRoleToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SystemRoles_systemRoleToken",
                schema: "Users",
                table: "Users",
                column: "systemRoleToken",
                principalSchema: "SystemBase",
                principalTable: "SystemRoles",
                principalColumn: "systemRoleToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SystemRoles_systemRoleToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "systemRoleToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SystemRoles_systemRoleToken",
                schema: "Users",
                table: "Users",
                column: "systemRoleToken",
                principalSchema: "SystemBase",
                principalTable: "SystemRoles",
                principalColumn: "systemRoleToken",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
