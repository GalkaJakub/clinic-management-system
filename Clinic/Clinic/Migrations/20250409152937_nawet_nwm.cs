using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class nawet_nwm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_AddressId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "AddressId1",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "AddressId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "AddressId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "AddressId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 4,
                column: "AddressId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 5,
                column: "AddressId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 6,
                column: "AddressId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId1",
                table: "Patients",
                column: "AddressId1",
                unique: true,
                filter: "[AddressId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Addresses_AddressId1",
                table: "Patients",
                column: "AddressId1",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Addresses_AddressId1",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AddressId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AddressId1",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AddressId1",
                table: "Patients");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId",
                unique: true);
        }
    }
}
