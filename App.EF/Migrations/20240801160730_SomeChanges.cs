using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "createdDate",
                schema: "SystemBase",
                table: "SystemRoleFunctions",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "fullCode",
                schema: "SystemBase",
                table: "SystemRoleFunctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                schema: "SystemBase",
                table: "SystemRoleFunctions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "updatedDate",
                schema: "SystemBase",
                table: "SystemRoleFunctions",
                type: "datetimeoffset",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdDate",
                schema: "SystemBase",
                table: "SystemRoleFunctions");

            migrationBuilder.DropColumn(
                name: "fullCode",
                schema: "SystemBase",
                table: "SystemRoleFunctions");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                schema: "SystemBase",
                table: "SystemRoleFunctions");

            migrationBuilder.DropColumn(
                name: "updatedDate",
                schema: "SystemBase",
                table: "SystemRoleFunctions");
        }
    }
}
