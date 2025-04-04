using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class stringEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabExams_ExamSelections_ExamSelectionId",
                table: "LabExams");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalExams_ExamSelections_ExamSelectionId",
                table: "PhysicalExams");

            migrationBuilder.DropIndex(
                name: "IX_PhysicalExams_ExamSelectionId",
                table: "PhysicalExams");

            migrationBuilder.DropIndex(
                name: "IX_LabExams_ExamSelectionId",
                table: "LabExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamSelections",
                table: "ExamSelections");

            migrationBuilder.DropColumn(
                name: "ExamSelectionId",
                table: "ExamSelections");

            migrationBuilder.AddColumn<string>(
                name: "ExamSelectionShortcut",
                table: "PhysicalExams",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LabExams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ExamSelectionShortcut",
                table: "LabExams",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ExamSelections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Shortcut",
                table: "ExamSelections",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamSelections",
                table: "ExamSelections",
                column: "Shortcut");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalExams_ExamSelectionShortcut",
                table: "PhysicalExams",
                column: "ExamSelectionShortcut");

            migrationBuilder.CreateIndex(
                name: "IX_LabExams_ExamSelectionShortcut",
                table: "LabExams",
                column: "ExamSelectionShortcut");

            migrationBuilder.AddForeignKey(
                name: "FK_LabExams_ExamSelections_ExamSelectionShortcut",
                table: "LabExams",
                column: "ExamSelectionShortcut",
                principalTable: "ExamSelections",
                principalColumn: "Shortcut",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalExams_ExamSelections_ExamSelectionShortcut",
                table: "PhysicalExams",
                column: "ExamSelectionShortcut",
                principalTable: "ExamSelections",
                principalColumn: "Shortcut",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabExams_ExamSelections_ExamSelectionShortcut",
                table: "LabExams");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalExams_ExamSelections_ExamSelectionShortcut",
                table: "PhysicalExams");

            migrationBuilder.DropIndex(
                name: "IX_PhysicalExams_ExamSelectionShortcut",
                table: "PhysicalExams");

            migrationBuilder.DropIndex(
                name: "IX_LabExams_ExamSelectionShortcut",
                table: "LabExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamSelections",
                table: "ExamSelections");

            migrationBuilder.DropColumn(
                name: "ExamSelectionShortcut",
                table: "PhysicalExams");

            migrationBuilder.DropColumn(
                name: "ExamSelectionShortcut",
                table: "LabExams");

            migrationBuilder.DropColumn(
                name: "Shortcut",
                table: "ExamSelections");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "LabExams",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "ExamSelections",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ExamSelectionId",
                table: "ExamSelections",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamSelections",
                table: "ExamSelections",
                column: "ExamSelectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalExams_ExamSelectionId",
                table: "PhysicalExams",
                column: "ExamSelectionId");

            migrationBuilder.CreateIndex(
                name: "IX_LabExams_ExamSelectionId",
                table: "LabExams",
                column: "ExamSelectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabExams_ExamSelections_ExamSelectionId",
                table: "LabExams",
                column: "ExamSelectionId",
                principalTable: "ExamSelections",
                principalColumn: "ExamSelectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalExams_ExamSelections_ExamSelectionId",
                table: "PhysicalExams",
                column: "ExamSelectionId",
                principalTable: "ExamSelections",
                principalColumn: "ExamSelectionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
