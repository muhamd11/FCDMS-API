using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDoctors_UserDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserEmployees_userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserPatients_userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserProfiles_userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDoctors_UserDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                column: "UserDoctorDatauserDoctorToken",
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
                name: "FK_Users_UserPatients_userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users",
                column: "userPatientDatauserPatientToken",
                principalSchema: "Users",
                principalTable: "UserPatients",
                principalColumn: "userPatientToken");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserProfiles_userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users",
                column: "userProfileDatauserProfileToken",
                principalSchema: "Users",
                principalTable: "UserProfiles",
                principalColumn: "userProfileToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDoctors_UserDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserEmployees_userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserPatients_userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserProfiles_userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDoctors_UserDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                column: "UserDoctorDatauserDoctorToken",
                principalSchema: "Users",
                principalTable: "UserDoctors",
                principalColumn: "userDoctorToken",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserEmployees_userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users",
                column: "userEmployeeDatauserEmployeeToken",
                principalSchema: "Users",
                principalTable: "UserEmployees",
                principalColumn: "userEmployeeToken",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserPatients_userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users",
                column: "userPatientDatauserPatientToken",
                principalSchema: "Users",
                principalTable: "UserPatients",
                principalColumn: "userPatientToken",
                onDelete: ReferentialAction.Cascade);

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
    }
}