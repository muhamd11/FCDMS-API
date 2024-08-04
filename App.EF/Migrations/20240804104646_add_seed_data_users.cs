using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class add_seed_data_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Users",
                table: "Users",
                columns: new[] { "userToken", "createdDate", "fullCode", "isDeleted", "systemRoleToken", "updatedDate", "userEmail", "userLoginName", "userName", "userPassword", "userPhone", "userPhoneCC", "userPhoneCCName", "userPhoneDialCode", "userType" },
                values: new object[] { new Guid("ade938f3-6406-4d09-a806-ab02e28c6902"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "1", null, new Guid("ad792233-ba34-40f0-afb6-ed4c742abb1f"), null, null, "admin", "مدير النظام", "MDAwMA==", null, null, null, null, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Users",
                keyColumn: "userToken",
                keyValue: new Guid("ade938f3-6406-4d09-a806-ab02e28c6902"));
        }
    }
}
