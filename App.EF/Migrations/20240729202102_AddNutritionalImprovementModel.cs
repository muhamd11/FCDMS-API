using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddNutritionalImprovementModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NutritionalImprovements",
                schema: "ClinicManagement",
                columns: table => new
                {
                    nutritionalImprovementToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientHeightInCm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    patientWeightInKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    patientBmr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
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
                        principalColumn: "userToken");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NutritionalImprovements",
                schema: "ClinicManagement");
        }
    }
}
