using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class adress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_AdressId",
                table: "Patients");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AdressId",
                table: "Patients",
                column: "AdressId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_AdressId",
                table: "Patients");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AdressId",
                table: "Patients",
                column: "AdressId");
        }
    }
}
