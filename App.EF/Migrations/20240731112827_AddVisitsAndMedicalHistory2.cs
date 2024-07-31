using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitsAndMedicalHistory2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "patientThyroidSensitivityMeasurement_measurementDate",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<bool>(
                name: "patientThyroidSensitivityMeasurement_isMeasured",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "patientSugarMeasurement_measurementDate",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<bool>(
                name: "patientSugarMeasurement_isMeasured",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "patientBloodPressureMeasurement_measurementDate",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<bool>(
                name: "patientBloodPressureMeasurement_isMeasured",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "patientThyroidSensitivityMeasurement_measurementDate",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "patientThyroidSensitivityMeasurement_isMeasured",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "patientSugarMeasurement_measurementDate",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "patientSugarMeasurement_isMeasured",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "patientBloodPressureMeasurement_measurementDate",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "patientBloodPressureMeasurement_isMeasured",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
