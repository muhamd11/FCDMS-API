using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddSequence2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FullCodeSequences",
                columns: table => new
                {
                    fullCodeSequenceToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nextValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullCodeSequences", x => x.fullCodeSequenceToken);
                });

            migrationBuilder.InsertData(
                table: "FullCodeSequences",
                columns: new[] { "fullCodeSequenceToken", "nextValue" },
                values: new object[] { new Guid("179bb587-4911-41f7-b206-84d9725cc920"), 99 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullCodeSequences");
        }
    }
}
