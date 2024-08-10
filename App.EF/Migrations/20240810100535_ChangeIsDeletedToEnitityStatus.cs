using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIsDeletedToEnitityStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                schema: "ClinicManagement",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                schema: "SystemBase",
                table: "SystemRoles");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                schema: "SystemBase",
                table: "SystemRoleFunctions");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                schema: "ClinicManagement",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                schema: "ClinicManagement",
                table: "NutritionalImprovements");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                schema: "ClinicManagement",
                table: "MedicalHistories");

            migrationBuilder.AddColumn<int>(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "Visits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "entityStatus",
                schema: "Users",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "entityStatus",
                schema: "SystemBase",
                table: "SystemRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "entityStatus",
                schema: "SystemBase",
                table: "SystemRoleFunctions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "Operations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "NutritionalImprovements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "SystemBase",
                table: "SystemRoles",
                keyColumn: "systemRoleToken",
                keyValue: new Guid("1b14e306-a0cd-4334-a30d-3f4d92b5ae68"),
                column: "entityStatus",
                value: null);

            migrationBuilder.UpdateData(
                schema: "SystemBase",
                table: "SystemRoles",
                keyColumn: "systemRoleToken",
                keyValue: new Guid("2b979b0d-66d7-4b2d-b048-e448c902b1fe"),
                column: "entityStatus",
                value: null);

            migrationBuilder.UpdateData(
                schema: "SystemBase",
                table: "SystemRoles",
                keyColumn: "systemRoleToken",
                keyValue: new Guid("ad792233-ba34-40f0-afb6-ed4c742abb1f"),
                column: "entityStatus",
                value: null);

            migrationBuilder.UpdateData(
                schema: "SystemBase",
                table: "SystemRoles",
                keyColumn: "systemRoleToken",
                keyValue: new Guid("f0a30312-33ad-4969-b904-cb2edfdaccc6"),
                column: "entityStatus",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Users",
                table: "Users",
                keyColumn: "userToken",
                keyValue: new Guid("ade938f3-6406-4d09-a806-ab02e28c6902"),
                column: "entityStatus",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "entityStatus",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "entityStatus",
                schema: "SystemBase",
                table: "SystemRoles");

            migrationBuilder.DropColumn(
                name: "entityStatus",
                schema: "SystemBase",
                table: "SystemRoleFunctions");

            migrationBuilder.DropColumn(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "NutritionalImprovements");

            migrationBuilder.DropColumn(
                name: "entityStatus",
                schema: "ClinicManagement",
                table: "MedicalHistories");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                schema: "ClinicManagement",
                table: "Visits",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                schema: "Users",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                schema: "SystemBase",
                table: "SystemRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                schema: "SystemBase",
                table: "SystemRoleFunctions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                schema: "ClinicManagement",
                table: "Operations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                schema: "ClinicManagement",
                table: "NutritionalImprovements",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "SystemBase",
                table: "SystemRoles",
                keyColumn: "systemRoleToken",
                keyValue: new Guid("1b14e306-a0cd-4334-a30d-3f4d92b5ae68"),
                column: "isDeleted",
                value: null);

            migrationBuilder.UpdateData(
                schema: "SystemBase",
                table: "SystemRoles",
                keyColumn: "systemRoleToken",
                keyValue: new Guid("2b979b0d-66d7-4b2d-b048-e448c902b1fe"),
                column: "isDeleted",
                value: null);

            migrationBuilder.UpdateData(
                schema: "SystemBase",
                table: "SystemRoles",
                keyColumn: "systemRoleToken",
                keyValue: new Guid("ad792233-ba34-40f0-afb6-ed4c742abb1f"),
                column: "isDeleted",
                value: null);

            migrationBuilder.UpdateData(
                schema: "SystemBase",
                table: "SystemRoles",
                keyColumn: "systemRoleToken",
                keyValue: new Guid("f0a30312-33ad-4969-b904-cb2edfdaccc6"),
                column: "isDeleted",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Users",
                table: "Users",
                keyColumn: "userToken",
                keyValue: new Guid("ade938f3-6406-4d09-a806-ab02e28c6902"),
                column: "isDeleted",
                value: null);
        }
    }
}
