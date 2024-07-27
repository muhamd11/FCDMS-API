using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDoctors_userDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserEmployees_userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserProfiles_userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_userToken",
                schema: "Users",
                table: "UserProfiles",
                column: "userToken",
                unique: true,
                filter: "[userToken] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmployees_userToken",
                schema: "Users",
                table: "UserEmployees",
                column: "userToken",
                unique: true,
                filter: "[userToken] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserDoctors_userToken",
                schema: "Users",
                table: "UserDoctors",
                column: "userToken",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDoctors_Users_userToken",
                schema: "Users",
                table: "UserDoctors",
                column: "userToken",
                principalSchema: "Users",
                principalTable: "Users",
                principalColumn: "userToken",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEmployees_Users_userToken",
                schema: "Users",
                table: "UserEmployees",
                column: "userToken",
                principalSchema: "Users",
                principalTable: "Users",
                principalColumn: "userToken");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Users_userToken",
                schema: "Users",
                table: "UserProfiles",
                column: "userToken",
                principalSchema: "Users",
                principalTable: "Users",
                principalColumn: "userToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDoctors_Users_userToken",
                schema: "Users",
                table: "UserDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEmployees_Users_userToken",
                schema: "Users",
                table: "UserEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Users_userToken",
                schema: "Users",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_userToken",
                schema: "Users",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserEmployees_userToken",
                schema: "Users",
                table: "UserEmployees");

            migrationBuilder.DropIndex(
                name: "IX_UserDoctors_userToken",
                schema: "Users",
                table: "UserDoctors");

            migrationBuilder.AddColumn<Guid>(
                name: "userDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_userDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                column: "userDoctorDatauserDoctorToken");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users",
                column: "userEmployeeDatauserEmployeeToken");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users",
                column: "userProfileDatauserProfileToken");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDoctors_userDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                column: "userDoctorDatauserDoctorToken",
                principalSchema: "Users",
                principalTable: "UserDoctors",
                principalColumn: "userDoctorToken");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserEmployees_userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users",
                column: "userEmployeeDatauserEmployeeToken",
                principalSchema: "Users",
                principalTable: "UserEmployees",
                principalColumn: "userEmployeeToken");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserProfiles_userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users",
                column: "userProfileDatauserProfileToken",
                principalSchema: "Users",
                principalTable: "UserProfiles",
                principalColumn: "userProfileToken");
        }
    }
}