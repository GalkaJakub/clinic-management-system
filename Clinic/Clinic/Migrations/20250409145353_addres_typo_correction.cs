using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class addres_typo_correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Addresses_AdressId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "Patients",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_AdressId",
                table: "Patients",
                newName: "IX_Patients_AddressId");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "Addresses",
                newName: "AddressId");

            migrationBuilder.AlterColumn<string>(
                name: "PESEL",
                table: "Patients",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Addresses_AddressId",
                table: "Patients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Addresses_AddressId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Patients",
                newName: "AdressId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                newName: "IX_Patients_AdressId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Addresses",
                newName: "AdressId");

            migrationBuilder.AlterColumn<string>(
                name: "PESEL",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Addresses_AdressId",
                table: "Patients",
                column: "AdressId",
                principalTable: "Addresses",
                principalColumn: "AdressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
