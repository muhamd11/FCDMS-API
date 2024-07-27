using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDialCodePhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userPhoneDialCode_2",
                schema: "Users",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "userPhoneDialCode_3",
                schema: "Users",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "userPhoneDialCode_4",
                schema: "Users",
                table: "UserProfiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userPhoneDialCode_2",
                schema: "Users",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userPhoneDialCode_3",
                schema: "Users",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userPhoneDialCode_4",
                schema: "Users",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}