using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class ondeletecascades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
        name: "FK_LabExams_Appointments_AppointmentId",
        table: "LabExams");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalExams_Appointments_AppointmentId",
                table: "PhysicalExams");

            migrationBuilder.AddForeignKey(
                name: "FK_LabExams_Appointments_AppointmentId",
                table: "LabExams",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalExams_Appointments_AppointmentId",
                table: "PhysicalExams",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
