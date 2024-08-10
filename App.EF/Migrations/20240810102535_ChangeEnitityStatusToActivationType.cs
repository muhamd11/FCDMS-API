using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEnitityStatusToActivationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "Visits",
                newName: "activationType");

            migrationBuilder.RenameColumn(
                name: "entityStatus",
                schema: "Users",
                table: "Users",
                newName: "activationType");

            migrationBuilder.RenameColumn(
                name: "entityStatus",
                schema: "SystemBase",
                table: "SystemRoles",
                newName: "activationType");

            migrationBuilder.RenameColumn(
                name: "entityStatus",
                schema: "SystemBase",
                table: "SystemRoleFunctions",
                newName: "activationType");

            migrationBuilder.RenameColumn(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "Operations",
                newName: "activationType");

            migrationBuilder.RenameColumn(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "NutritionalImprovements",
                newName: "activationType");

            migrationBuilder.RenameColumn(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                newName: "activationType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "activationType",
                schema: "ClinicManagement",
                table: "Visits",
                newName: "entityStatus");

            migrationBuilder.RenameColumn(
                name: "activationType",
                schema: "Users",
                table: "Users",
                newName: "entityStatus");

            migrationBuilder.RenameColumn(
                name: "activationType",
                schema: "SystemBase",
                table: "SystemRoles",
                newName: "entityStatus");

            migrationBuilder.RenameColumn(
                name: "activationType",
                schema: "SystemBase",
                table: "SystemRoleFunctions",
                newName: "entityStatus");

            migrationBuilder.RenameColumn(
                name: "activationType",
                schema: "ClinicManagement",
                table: "Operations",
                newName: "entityStatus");

            migrationBuilder.RenameColumn(
                name: "activationType",
                schema: "ClinicManagement",
                table: "NutritionalImprovements",
                newName: "entityStatus");

            migrationBuilder.RenameColumn(
                name: "activationType",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                newName: "entityStatus");
        }
    }
}
