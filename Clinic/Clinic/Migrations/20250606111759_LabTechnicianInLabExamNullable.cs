using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class LabTechnicianInLabExamNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabExams_LabTechnicians_LabTechnicianId",
                table: "LabExams");

            migrationBuilder.AlterColumn<int>(
                name: "LabTechnicianId",
                table: "LabExams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LabExams_LabTechnicians_LabTechnicianId",
                table: "LabExams",
                column: "LabTechnicianId",
                principalTable: "LabTechnicians",
                principalColumn: "LabTechnicianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabExams_LabTechnicians_LabTechnicianId",
                table: "LabExams");

            migrationBuilder.AlterColumn<int>(
                name: "LabTechnicianId",
                table: "LabExams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LabExams_LabTechnicians_LabTechnicianId",
                table: "LabExams",
                column: "LabTechnicianId",
                principalTable: "LabTechnicians",
                principalColumn: "LabTechnicianId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
