using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableFieldsToVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userPatientComplaining",
                schema: "ClinicManagement",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "medications",
                schema: "ClinicManagement",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "generalNotes",
                schema: "ClinicManagement",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "fetalInformations_fetalWeightInKg",
                schema: "ClinicManagement",
                table: "Visits",
                type: "decimal(30,18)",
                precision: 30,
                scale: 18,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,18)",
                oldPrecision: 30,
                oldScale: 18);

            migrationBuilder.AlterColumn<decimal>(
                name: "fetalInformations_fetalHeartBeatPerMinute",
                schema: "ClinicManagement",
                table: "Visits",
                type: "decimal(30,18)",
                precision: 30,
                scale: 18,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,18)",
                oldPrecision: 30,
                oldScale: 18);

            migrationBuilder.AlterColumn<int>(
                name: "fetalInformations_fetalGender",
                schema: "ClinicManagement",
                table: "Visits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "fetalInformations_fetalAgeInWeeks",
                schema: "ClinicManagement",
                table: "Visits",
                type: "decimal(30,18)",
                precision: 30,
                scale: 18,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,18)",
                oldPrecision: 30,
                oldScale: 18);

            migrationBuilder.AlterColumn<decimal>(
                name: "fetalInformations_fetalAgeInMonths",
                schema: "ClinicManagement",
                table: "Visits",
                type: "decimal(30,18)",
                precision: 30,
                scale: 18,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,18)",
                oldPrecision: 30,
                oldScale: 18);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userPatientComplaining",
                schema: "ClinicManagement",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "medications",
                schema: "ClinicManagement",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "generalNotes",
                schema: "ClinicManagement",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "fetalInformations_fetalWeightInKg",
                schema: "ClinicManagement",
                table: "Visits",
                type: "decimal(30,18)",
                precision: 30,
                scale: 18,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,18)",
                oldPrecision: 30,
                oldScale: 18,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "fetalInformations_fetalHeartBeatPerMinute",
                schema: "ClinicManagement",
                table: "Visits",
                type: "decimal(30,18)",
                precision: 30,
                scale: 18,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,18)",
                oldPrecision: 30,
                oldScale: 18,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fetalInformations_fetalGender",
                schema: "ClinicManagement",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "fetalInformations_fetalAgeInWeeks",
                schema: "ClinicManagement",
                table: "Visits",
                type: "decimal(30,18)",
                precision: 30,
                scale: 18,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,18)",
                oldPrecision: 30,
                oldScale: 18,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "fetalInformations_fetalAgeInMonths",
                schema: "ClinicManagement",
                table: "Visits",
                type: "decimal(30,18)",
                precision: 30,
                scale: 18,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(30,18)",
                oldPrecision: 30,
                oldScale: 18,
                oldNullable: true);
        }
    }
}