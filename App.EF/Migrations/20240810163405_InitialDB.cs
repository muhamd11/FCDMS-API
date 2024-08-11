using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
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
                name: "OtpRecords",
                schema: "Users",
                columns: table => new
                {
                    OtpToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userOtp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpRecords", x => x.OtpToken);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoleFunctions",
                schema: "SystemBase",
                columns: table => new
                {
                    systemRoleFunctionToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    systemRoleToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    functionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    functionsType = table.Column<int>(type: "int", nullable: false),
                    customizeFunctionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    moduleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    functionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isHavePrivilege = table.Column<bool>(type: "bit", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primaryFullCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activationType = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                    userTypeToken = table.Column<int>(type: "int", nullable: false),
                    systemRoleCanUseDefault = table.Column<bool>(type: "bit", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primaryFullCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activationType = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.systemRoleToken);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Users",
                columns: table => new
                {
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneDialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userLoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userTypeToken = table.Column<int>(type: "int", nullable: false),
                    systemRoleToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fullCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primaryFullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    activationType = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "systemRoleToken");
                });

            migrationBuilder.CreateTable(
                name: "LogActions",
                schema: "SystemBase",
                columns: table => new
                {
                    logActionId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    modelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    actionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oldActionData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    newActionData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogActions", x => x.logActionId);
                    table.ForeignKey(
                        name: "FK_LogActions_Users_userToken",
                        column: x => x.userToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken");
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                schema: "ClinicManagement",
                columns: table => new
                {
                    medicalHistoryToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientSugarMeasurement_isMeasured = table.Column<bool>(type: "bit", nullable: true),
                    patientSugarMeasurement_measurementValue = table.Column<double>(type: "float", nullable: true),
                    patientSugarMeasurement_measurementDate = table.Column<DateOnly>(type: "date", nullable: true),
                    patientBloodPressureMeasurement_isMeasured = table.Column<bool>(type: "bit", nullable: true),
                    patientBloodPressureMeasurement_measurementValue = table.Column<double>(type: "float", nullable: true),
                    patientBloodPressureMeasurement_measurementDate = table.Column<DateOnly>(type: "date", nullable: true),
                    patientThyroidSensitivityMeasurement_isMeasured = table.Column<bool>(type: "bit", nullable: true),
                    patientThyroidSensitivityMeasurement_measurementValue = table.Column<double>(type: "float", nullable: true),
                    patientThyroidSensitivityMeasurement_measurementDate = table.Column<DateOnly>(type: "date", nullable: true),
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    primaryFullCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activationType = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.medicalHistoryToken);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Users_userPatientToken",
                        column: x => x.userPatientToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalImprovements",
                schema: "ClinicManagement",
                columns: table => new
                {
                    nutritionalImprovementToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientHeightInCm = table.Column<decimal>(type: "decimal(30,18)", precision: 30, scale: 18, nullable: false),
                    patientWeightInKg = table.Column<decimal>(type: "decimal(30,18)", precision: 30, scale: 18, nullable: false),
                    patientBmr = table.Column<decimal>(type: "decimal(30,18)", precision: 30, scale: 18, nullable: false),
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    primaryFullCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activationType = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalImprovements", x => x.nutritionalImprovementToken);
                    table.ForeignKey(
                        name: "FK_NutritionalImprovements_Users_userPatientToken",
                        column: x => x.userPatientToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken",
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
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    primaryFullCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activationType = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.operationToken);
                    table.ForeignKey(
                        name: "FK_Operations_Users_userPatientToken",
                        column: x => x.userPatientToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDoctors",
                schema: "Users",
                columns: table => new
                {
                    userDoctorToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDoctors", x => x.userDoctorToken);
                    table.ForeignKey(
                        name: "FK_UserDoctors_Users_userToken",
                        column: x => x.userToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_UserEmployees_Users_userToken",
                        column: x => x.userToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken");
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
                    table.ForeignKey(
                        name: "FK_UserPatients_Users_userToken",
                        column: x => x.userToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken");
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                schema: "Users",
                columns: table => new
                {
                    userProfileToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userPhone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhone4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userBirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.userProfileToken);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_userToken",
                        column: x => x.userToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken");
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                schema: "ClinicManagement",
                columns: table => new
                {
                    visitToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    lastPeriodDate = table.Column<DateOnly>(type: "date", nullable: false),
                    expectedDateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    userPatientComplaining = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numberOfChildren = table.Column<int>(type: "int", nullable: false),
                    medications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    generalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fetalInformations_fetalHeartBeatPerMinute = table.Column<decimal>(type: "decimal(30,18)", precision: 30, scale: 18, nullable: false),
                    fetalInformations_fetalAgeInWeeks = table.Column<decimal>(type: "decimal(30,18)", precision: 30, scale: 18, nullable: false),
                    fetalInformations_fetalAgeInMonths = table.Column<decimal>(type: "decimal(30,18)", precision: 30, scale: 18, nullable: false),
                    fetalInformations_fetalWeightInKg = table.Column<decimal>(type: "decimal(30,18)", precision: 30, scale: 18, nullable: false),
                    fetalInformations_fetalGender = table.Column<int>(type: "int", nullable: false),
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    primaryFullCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activationType = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.visitToken);
                    table.ForeignKey(
                        name: "FK_Visits_Users_userPatientToken",
                        column: x => x.userPatientToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "SystemBase",
                table: "SystemRoles",
                columns: new[] { "systemRoleToken", "activationType", "createdDate", "fullCode", "primaryFullCode", "systemRoleCanUseDefault", "systemRoleDescription", "systemRoleName", "updatedDate", "userTypeToken" },
                values: new object[,]
                {
                    { new Guid("1b14e306-a0cd-4334-a30d-3f4d92b5ae68"), null, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "3", null, true, "مضافة من قبل النظام", "صلاحيات موظف اساسية", null, 3 },
                    { new Guid("2b979b0d-66d7-4b2d-b048-e448c902b1fe"), null, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "4", null, true, "مضافة من قبل النظام", "صلاحيات مريض اساسية", null, 4 },
                    { new Guid("ad792233-ba34-40f0-afb6-ed4c742abb1f"), null, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "1", null, true, "مضافة من قبل النظام", "صلاحيات مطور اساسية", null, 1 },
                    { new Guid("f0a30312-33ad-4969-b904-cb2edfdaccc6"), null, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "2", null, true, "مضافة من قبل النظام", "صلاحيات دكتور اساسية", null, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Users",
                table: "Users",
                columns: new[] { "userToken", "activationType", "createdDate", "fullCode", "primaryFullCode", "systemRoleToken", "updatedDate", "userEmail", "userLoginName", "userName", "userPassword", "userPhone", "userPhoneCC", "userPhoneCCName", "userPhoneDialCode", "userTypeToken" },
                values: new object[] { new Guid("ade938f3-6406-4d09-a806-ab02e28c6902"), null, new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "1", "Developer_1", new Guid("ad792233-ba34-40f0-afb6-ed4c742abb1f"), null, null, "admin", "مدير النظام", "MDAwMA==", null, null, null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_LogActions_userToken",
                schema: "SystemBase",
                table: "LogActions",
                column: "userToken");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_fullCode",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                column: "fullCode",
                unique: true,
                filter: "[fullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_userPatientToken",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                column: "userPatientToken");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalImprovements_createdDate",
                schema: "ClinicManagement",
                table: "NutritionalImprovements",
                column: "createdDate");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalImprovements_fullCode",
                schema: "ClinicManagement",
                table: "NutritionalImprovements",
                column: "fullCode",
                unique: true,
                filter: "[fullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalImprovements_userPatientToken",
                schema: "ClinicManagement",
                table: "NutritionalImprovements",
                column: "userPatientToken");

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
                name: "IX_Operations_userPatientToken",
                schema: "ClinicManagement",
                table: "Operations",
                column: "userPatientToken");

            migrationBuilder.CreateIndex(
                name: "IX_UserDoctors_userToken",
                schema: "Users",
                table: "UserDoctors",
                column: "userToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEmployees_userToken",
                schema: "Users",
                table: "UserEmployees",
                column: "userToken",
                unique: true,
                filter: "[userToken] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserPatients_userToken",
                schema: "Users",
                table: "UserPatients",
                column: "userToken",
                unique: true,
                filter: "[userToken] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_userToken",
                schema: "Users",
                table: "UserProfiles",
                column: "userToken",
                unique: true,
                filter: "[userToken] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_primaryFullCode",
                schema: "Users",
                table: "Users",
                column: "primaryFullCode",
                unique: true,
                filter: "[primaryFullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_systemRoleToken",
                schema: "Users",
                table: "Users",
                column: "systemRoleToken");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userTypeToken",
                schema: "Users",
                table: "Users",
                column: "userTypeToken");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_fullCode",
                schema: "ClinicManagement",
                table: "Visits",
                column: "fullCode",
                unique: true,
                filter: "[fullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_userPatientToken",
                schema: "ClinicManagement",
                table: "Visits",
                column: "userPatientToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogActions",
                schema: "SystemBase");

            migrationBuilder.DropTable(
                name: "MedicalHistories",
                schema: "ClinicManagement");

            migrationBuilder.DropTable(
                name: "NutritionalImprovements",
                schema: "ClinicManagement");

            migrationBuilder.DropTable(
                name: "Operations",
                schema: "ClinicManagement");

            migrationBuilder.DropTable(
                name: "OtpRecords",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "SystemRoleFunctions",
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

            migrationBuilder.DropTable(
                name: "Visits",
                schema: "ClinicManagement");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "SystemRoles",
                schema: "SystemBase");
        }
    }
}
