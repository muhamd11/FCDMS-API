using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_userEmail",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userLoginName",
                schema: "Users",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "userLoginName",
                schema: "Users",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "userEmail",
                schema: "Users",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userEmail",
                schema: "Users",
                table: "Users",
                column: "userEmail",
                unique: true,
                filter: "[userEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userLoginName",
                schema: "Users",
                table: "Users",
                column: "userLoginName",
                unique: true,
                filter: "[userLoginName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_userEmail",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userLoginName",
                schema: "Users",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "userLoginName",
                schema: "Users",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userEmail",
                schema: "Users",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_userEmail",
                schema: "Users",
                table: "Users",
                column: "userEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_userLoginName",
                schema: "Users",
                table: "Users",
                column: "userLoginName",
                unique: true);
        }
    }
}
