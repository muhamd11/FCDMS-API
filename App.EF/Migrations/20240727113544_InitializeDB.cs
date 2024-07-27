using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SystemBase");

            migrationBuilder.EnsureSchema(
                name: "ClinicManagement");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "LogActions",
                schema: "SystemBase",
                columns: table => new
                {
                    logActionToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    modelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    actionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oldData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    newData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogActions", x => x.logActionToken);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoleFunctions",
                schema: "SystemBase",
                columns: table => new
                {
                    systemRoleFunctionToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    systemRoleToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    functionsType = table.Column<int>(type: "int", nullable: false),
                    moduleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    functionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isHavePrivilege = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoleFunctions", x => x.systemRoleFunctionToken);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoles",
                schema: "SystemBase",
                columns: table => new
                {
                    systemRoleToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    systemRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    systemRoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    systemRoleUserType = table.Column<int>(type: "int", nullable: false),
                    systemRoleCanUseDefault = table.Column<bool>(type: "bit", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.systemRoleToken);
                });

            migrationBuilder.CreateTable(
                name: "UserDoctors",
                schema: "Users",
                columns: table => new
                {
                    userDoctorToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDoctors", x => x.userDoctorToken);
                });

            migrationBuilder.CreateTable(
                name: "UserEmployees",
                schema: "Users",
                columns: table => new
                {
                    userEmployeeToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmployees", x => x.userEmployeeToken);
                });

            migrationBuilder.CreateTable(
                name: "UserPatients",
                schema: "Users",
                columns: table => new
                {
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    userPatientBloodType = table.Column<int>(type: "int", nullable: false),
                    userPatientChildrenCount = table.Column<int>(type: "int", nullable: false),
                    userPatientAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPatients", x => x.userPatientToken);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                schema: "Users",
                columns: table => new
                {
                    userProfileToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userPhone_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhoneDialCode_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhoneCC_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhoneCCName_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhone_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhoneDialCode_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhoneCC_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhoneCCName_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhone_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhoneDialCode_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhoneCC_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhoneCCName_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userBirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.userProfileToken);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Users",
                columns: table => new
                {
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userPhone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userPhoneDialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhoneCC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPhoneCCName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userLoginName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userType = table.Column<int>(type: "int", nullable: false),
                    systemRoleToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userProfileDatauserProfileToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userPatientDatauserPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userEmployeeDatauserEmployeeToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserDoctorDatauserDoctorToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userToken);
                    table.ForeignKey(
                        name: "FK_Users_SystemRoles_systemRoleToken",
                        column: x => x.systemRoleToken,
                        principalSchema: "SystemBase",
                        principalTable: "SystemRoles",
                        principalColumn: "systemRoleToken",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserDoctors_UserDoctorDatauserDoctorToken",
                        column: x => x.UserDoctorDatauserDoctorToken,
                        principalSchema: "Users",
                        principalTable: "UserDoctors",
                        principalColumn: "userDoctorToken",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserEmployees_userEmployeeDatauserEmployeeToken",
                        column: x => x.userEmployeeDatauserEmployeeToken,
                        principalSchema: "Users",
                        principalTable: "UserEmployees",
                        principalColumn: "userEmployeeToken",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserPatients_userPatientDatauserPatientToken",
                        column: x => x.userPatientDatauserPatientToken,
                        principalSchema: "Users",
                        principalTable: "UserPatients",
                        principalColumn: "userPatientToken",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserProfiles_userProfileDatauserProfileToken",
                        column: x => x.userProfileDatauserProfileToken,
                        principalSchema: "Users",
                        principalTable: "UserProfiles",
                        principalColumn: "userProfileToken",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                schema: "ClinicManagement",
                columns: table => new
                {
                    operationToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    operationName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    operationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.operationToken);
                    table.ForeignKey(
                        name: "FK_Operations_Users_userToken",
                        column: x => x.userToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_fullCode",
                schema: "ClinicManagement",
                table: "Operations",
                column: "fullCode",
                unique: true,
                filter: "[fullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_operationDate",
                schema: "ClinicManagement",
                table: "Operations",
                column: "operationDate");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_operationName",
                schema: "ClinicManagement",
                table: "Operations",
                column: "operationName");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_userToken",
                schema: "ClinicManagement",
                table: "Operations",
                column: "userToken");

            migrationBuilder.CreateIndex(
                name: "IX_Users_fullCode",
                schema: "Users",
                table: "Users",
                column: "fullCode",
                unique: true,
                filter: "[fullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_systemRoleToken",
                schema: "Users",
                table: "Users",
                column: "systemRoleToken");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDoctorDatauserDoctorToken",
                schema: "Users",
                table: "Users",
                column: "UserDoctorDatauserDoctorToken");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userEmail",
                schema: "Users",
                table: "Users",
                column: "userEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_userEmployeeDatauserEmployeeToken",
                schema: "Users",
                table: "Users",
                column: "userEmployeeDatauserEmployeeToken");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userLoginName",
                schema: "Users",
                table: "Users",
                column: "userLoginName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_userPatientDatauserPatientToken",
                schema: "Users",
                table: "Users",
                column: "userPatientDatauserPatientToken");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userPhone",
                schema: "Users",
                table: "Users",
                column: "userPhone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_userProfileDatauserProfileToken",
                schema: "Users",
                table: "Users",
                column: "userProfileDatauserProfileToken");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userType",
                schema: "Users",
                table: "Users",
                column: "userType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogActions",
                schema: "SystemBase");

            migrationBuilder.DropTable(
                name: "Operations",
                schema: "ClinicManagement");

            migrationBuilder.DropTable(
                name: "SystemRoleFunctions",
                schema: "SystemBase");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "SystemRoles",
                schema: "SystemBase");

            migrationBuilder.DropTable(
                name: "UserDoctors",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "UserEmployees",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "UserPatients",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "UserProfiles",
                schema: "Users");
        }
    }
}