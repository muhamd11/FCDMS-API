using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitsAndMedicalHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                schema: "ClinicManagement",
                columns: table => new
                {
                    medicalHistoryToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientSugarMeasurement_isMeasured = table.Column<bool>(type: "bit", nullable: false),
                    patientSugarMeasurement_measurementValue = table.Column<double>(type: "float", nullable: true),
                    patientSugarMeasurement_measurementDate = table.Column<DateOnly>(type: "date", nullable: false),
                    patientBloodPressureMeasurement_isMeasured = table.Column<bool>(type: "bit", nullable: false),
                    patientBloodPressureMeasurement_measurementValue = table.Column<double>(type: "float", nullable: true),
                    patientBloodPressureMeasurement_measurementDate = table.Column<DateOnly>(type: "date", nullable: false),
                    patientThyroidSensitivityMeasurement_isMeasured = table.Column<bool>(type: "bit", nullable: false),
                    patientThyroidSensitivityMeasurement_measurementValue = table.Column<double>(type: "float", nullable: true),
                    patientThyroidSensitivityMeasurement_measurementDate = table.Column<DateOnly>(type: "date", nullable: false),
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
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
                    fetalInformations_fetalHeartBeatPerMinute = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fetalInformations_fetalAgeInWeeks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fetalInformations_fetalAgeInMonths = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fetalInformations_fetalWeightInKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
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
                        principalColumn: "userToken");
                });

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
                name: "MedicalHistories",
                schema: "ClinicManagement");

            migrationBuilder.DropTable(
                name: "Visits",
                schema: "ClinicManagement");
        }
    }
}