using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitDateFieldToVisit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastPeriodDate",
                schema: "ClinicManagement",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "numberOfChildren",
                schema: "ClinicManagement",
                table: "Visits");

            migrationBuilder.AddColumn<DateOnly>(
                name: "lastPeriodDate",
                schema: "Users",
                table: "UserPatients",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastPeriodDate",
                schema: "Users",
                table: "UserPatients");

            migrationBuilder.AddColumn<DateOnly>(
                name: "lastPeriodDate",
                schema: "ClinicManagement",
                table: "Visits",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "numberOfChildren",
                schema: "ClinicManagement",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
