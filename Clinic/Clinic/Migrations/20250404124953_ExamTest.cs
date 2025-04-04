using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class ExamTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExamSelections",
                columns: new[] { "Shortcut", "Name", "Type" },
                values: new object[,]
                {
                    { "cukier", "Sprawdzenie poziomu cukru we krwi", "Physical" },
                    { "krew", "Pobieranie krwi", "Lab" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExamSelections",
                keyColumn: "Shortcut",
                keyValue: "cukier");

            migrationBuilder.DeleteData(
                table: "ExamSelections",
                keyColumn: "Shortcut",
                keyValue: "krew");
        }
    }
}
