using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToUserEmployee2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userGender",
                schema: "Users",
                table: "UserEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "userNationalId",
                schema: "Users",
                table: "UserEmployees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userNationality",
                schema: "Users",
                table: "UserEmployees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userGender",
                schema: "Users",
                table: "UserEmployees");

            migrationBuilder.DropColumn(
                name: "userNationalId",
                schema: "Users",
                table: "UserEmployees");

            migrationBuilder.DropColumn(
                name: "userNationality",
                schema: "Users",
                table: "UserEmployees");
        }
    }
}
