using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class testData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ExamSelectionShortcut",
                table: "PhysicalExams");

            migrationBuilder.DropColumn(
                name: "ExamSelectionShortcut",
                table: "LabExams");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ExamSelectionId",
                table: "PhysicalExams",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ExamSelectionId",
                table: "LabExams",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "HomeNumber",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApartNumber",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AdressId", "ApartNumber", "City", "HomeNumber", "Street" },
                values: new object[,]
                {
                    { 1, null, "Gliwice", "304", "Akademicka" },
                    { 2, null, "Warsaw", "26D", "Pine" },
                    { 3, null, "Warsaw", "25C", "Oak" },
                    { 4, null, "Wroclaw", "53A", "High" },
                    { 5, null, "Poznan", "42D", "Oak" },
                    { 6, null, "Krakow", "97B", "Pine" }
                });

            migrationBuilder.InsertData(
                table: "ExamSelections",
                columns: new[] { "Shortcut", "Name", "Type" },
                values: new object[,]
                {
                    { "Blood", "Blood Test", "Lab" },
                    { "Gen", "General Checkup", "Physical" },
                    { "XR", "X-Ray", "Lab" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Login",
                value: "Jakub");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Login",
                value: "Wiktor");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Login",
                value: "Jakub");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Login",
                value: "Kacper");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Login",
                value: "Michał");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "AdressId", "Name", "PESEL", "Surname" },
                values: new object[,]
                {
                    { 1, 1, "Gabriel", "65110414558", "Drabik" },
                    { 2, 2, "Michael", "57752850000", "Brown" },
                    { 3, 3, "Emma", "18204590000", "Taylor" },
                    { 4, 4, "John", "87673060000", "Brown" },
                    { 5, 5, "Emma", "99339650000", "Taylor" },
                    { 6, 6, "Anna", "73435320000", "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointemntId", "AppointmentDate", "Description", "Diagnosis", "DoctorId", "PatientId", "ReceptionistId", "RegistrationDate", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ból głowy", null, 1, 1, 2, new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awaiting" },
                    { 2, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ból zeba", null, 1, 2, 2, new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awaiting" },
                    { 3, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gorączka i mocny ból głowy", null, 1, 4, 2, new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Awaiting" }
                });

            migrationBuilder.InsertData(
                table: "LabExams",
                columns: new[] { "LabExamId", "AcceptDate", "AppointmentId", "DoctorsNotes", "ExamDate", "ExamSelectionId", "HeadLabNotes", "HeadLabTechnicianId", "LabTechnicianId", "RequestDate", "Result", "Status" },
                values: new object[,]
                {
                    { 1, null, 1, null, null, "Blood", null, 3, 4, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awaiting" },
                    { 2, null, 1, null, null, "XR", null, 3, 4, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Awaiting" }
                });

            migrationBuilder.InsertData(
                table: "PhysicalExams",
                columns: new[] { "PhisicalExamId", "AppointmentId", "ExamSelectionId", "Result" },
                values: new object[] { 1, 1, "Gen", "All good" });

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
                principalColumn: "Shortcut",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalExams_ExamSelections_ExamSelectionId",
                table: "PhysicalExams",
                column: "ExamSelectionId",
                principalTable: "ExamSelections",
                principalColumn: "Shortcut",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointemntId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointemntId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LabExams",
                keyColumn: "LabExamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LabExams",
                keyColumn: "LabExamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PhysicalExams",
                keyColumn: "PhisicalExamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AdressId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AdressId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AdressId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointemntId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExamSelections",
                keyColumn: "Shortcut",
                keyValue: "Blood");

            migrationBuilder.DeleteData(
                table: "ExamSelections",
                keyColumn: "Shortcut",
                keyValue: "Gen");

            migrationBuilder.DeleteData(
                table: "ExamSelections",
                keyColumn: "Shortcut",
                keyValue: "XR");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AdressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AdressId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AdressId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ExamSelectionId",
                table: "PhysicalExams",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<string>(
                name: "ExamSelectionShortcut",
                table: "PhysicalExams",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ExamSelectionId",
                table: "LabExams",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<string>(
                name: "ExamSelectionShortcut",
                table: "LabExams",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "HomeNumber",
                table: "Addresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ApartNumber",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
