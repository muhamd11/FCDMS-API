using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddForgetPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForgetPasswords",
                schema: "Users",
                columns: table => new
                {
                    forgetPasswordToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userOtp = table.Column<int>(type: "int", nullable: false),
                    expireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgetPasswords", x => x.forgetPasswordToken);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForgetPasswords",
                schema: "Users");
        }
    }
}
