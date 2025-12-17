using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoursePracticalApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateNotesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "235f4810-7f9b-41a7-bbe4-0ec0552003fe");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "32be0b71-ff70-40f9-bad6-6dc104f44b11");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "74080050-5084-47b0-befe-be4b1599dc3a");

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30a412ae-7a16-4096-b1cd-6c35d1617aa9", "2c35c750-3f0c-4280-b833-37294bdcebd3", "APP_ADMIN", "APP_ADMIN" },
                    { "b3d0870c-db07-497b-8e9b-24489e6d615e", "748b724b-aa3f-4b8d-8eb0-afc58b6a6749", "RECEPTIONEST", "RECEPTIONEST" },
                    { "c6436b57-ef8e-4fe5-987b-509b92c15956", "d10feb24-4b74-4fd6-a9d7-aca20b0215ec", "DOCTOR", "DOCTOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_AppointmentId",
                table: "Note",
                column: "AppointmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "30a412ae-7a16-4096-b1cd-6c35d1617aa9");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b3d0870c-db07-497b-8e9b-24489e6d615e");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c6436b57-ef8e-4fe5-987b-509b92c15956");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Appointments");

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "235f4810-7f9b-41a7-bbe4-0ec0552003fe", "af7a9aec-0cb8-4284-90d5-51d7be0a59fa", "RECEPTIONEST", "RECEPTIONEST" },
                    { "32be0b71-ff70-40f9-bad6-6dc104f44b11", "8fecb681-9cfb-4edd-a212-4f702731a44a", "APP_ADMIN", "APP_ADMIN" },
                    { "74080050-5084-47b0-befe-be4b1599dc3a", "0a4daf81-bdf9-46cc-85d0-986ab2961b8d", "DOCTOR", "DOCTOR" }
                });
        }
    }
}
