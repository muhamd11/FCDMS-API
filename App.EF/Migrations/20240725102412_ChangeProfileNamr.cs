using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProfileNamr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserProfiles_userProfileToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "userProfileToken",
                schema: "Users",
                table: "Users",
                newName: "userProfileDatauserProfileToken");

            migrationBuilder.RenameIndex(
                name: "IX_Users_userProfileToken",
                schema: "Users",
                table: "Users",
                newName: "IX_Users_userProfileDatauserProfileToken");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserProfiles_userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users",
                column: "userProfileDatauserProfileToken",
                principalSchema: "Users",
                principalTable: "UserProfiles",
                principalColumn: "userProfileToken",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserProfiles_userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users",
                newName: "userProfileToken");

            migrationBuilder.RenameIndex(
                name: "IX_Users_userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users",
                newName: "IX_Users_userProfileToken");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserProfiles_userProfileToken",
                schema: "Users",
                table: "Users",
                column: "userProfileToken",
                principalSchema: "Users",
                principalTable: "UserProfiles",
                principalColumn: "userProfileToken",
                onDelete: ReferentialAction.Cascade);
        }
    }
}