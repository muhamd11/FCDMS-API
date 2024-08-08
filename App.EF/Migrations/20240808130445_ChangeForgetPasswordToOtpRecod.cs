using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForgetPasswordToOtpRecod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForgetPasswords",
                schema: "Users");

            migrationBuilder.CreateTable(
                name: "OtpRecords",
                schema: "Users",
                columns: table => new
                {
                    OtpToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userOtp = table.Column<int>(type: "int", nullable: false),
                    expireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpRecords", x => x.OtpToken);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtpRecords",
                schema: "Users");

            migrationBuilder.CreateTable(
                name: "ForgetPasswords",
                schema: "Users",
                columns: table => new
                {
                    forgetPasswordToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    expireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userOtp = table.Column<int>(type: "int", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgetPasswords", x => x.forgetPasswordToken);
                });
        }
    }
}