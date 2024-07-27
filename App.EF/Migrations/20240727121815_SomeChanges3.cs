using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDoctors_UserDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserPatients_userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                newName: "userDoctorDatauserDoctorToken");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                newName: "IX_Users_userDoctorDatauserDoctorToken");

            migrationBuilder.CreateIndex(
                name: "IX_UserPatients_userToken",
                schema: "Users",
                table: "UserPatients",
                column: "userToken",
                unique: true,
                filter: "[userToken] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPatients_Users_userToken",
                schema: "Users",
                table: "UserPatients",
                column: "userToken",
                principalSchema: "Users",
                principalTable: "Users",
                principalColumn: "userToken");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDoctors_userDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                column: "userDoctorDatauserDoctorToken",
                principalSchema: "Users",
                principalTable: "UserDoctors",
                principalColumn: "userDoctorToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPatients_Users_userToken",
                schema: "Users",
                table: "UserPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDoctors_userDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserPatients_userToken",
                schema: "Users",
                table: "UserPatients");

            migrationBuilder.RenameColumn(
                name: "userDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                newName: "UserDoctorDatauserDoctorToken");

            migrationBuilder.RenameIndex(
                name: "IX_Users_userDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                newName: "IX_Users_UserDoctorDatauserDoctorToken");

            migrationBuilder.AddColumn<Guid>(
                name: "userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users",
                column: "userPatientDatauserPatientToken");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDoctors_UserDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                column: "UserDoctorDatauserDoctorToken",
                principalSchema: "Users",
                principalTable: "UserDoctors",
                principalColumn: "userDoctorToken");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserPatients_userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users",
                column: "userPatientDatauserPatientToken",
                principalSchema: "Users",
                principalTable: "UserPatients",
                principalColumn: "userPatientToken");
        }
    }
}