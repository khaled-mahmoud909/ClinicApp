using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursePracticalApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Appointments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Appointments",
                newName: "Duration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Appointments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Appointments",
                newName: "NoteId");
        }
    }
}
