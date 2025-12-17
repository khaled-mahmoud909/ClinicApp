using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoursePracticalApp.Migrations
{
    /// <inheritdoc />
    public partial class TablesRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecialityNum",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Appointments_AppointmentId",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

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
                name: "FirstName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Specialities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SpecialityNum",
                table: "Doctors",
                newName: "SpecialityId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_SpecialityNum",
                table: "Doctors",
                newName: "IX_Doctors_SpecialityId");

            migrationBuilder.RenameIndex(
                name: "IX_Note_AppointmentId",
                table: "Notes",
                newName: "IX_Notes_AppointmentId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "auth",
                table: "Users",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "auth",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                schema: "auth",
                table: "Users",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "auth",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "auth",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Receptionists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptionists_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f1ac7a4-30a6-48ea-b85d-1211c1f7ca66", "38020dea-5bde-4028-9ea5-edeedf9e3b4a", "APP_ADMIN", "APP_ADMIN" },
                    { "8c9b308f-f178-4482-af1c-2ddee4f41b8c", "ec916a39-c850-4803-97cd-aec3ec2e4572", "DOCTOR", "DOCTOR" },
                    { "f440851c-8e7e-437e-9823-ea1d603a858d", "97fffa24-389a-4912-8e62-530542523bc7", "RECEPTIONEST", "RECEPTIONEST" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AppUserId",
                table: "Doctors",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_AppUserId",
                table: "Receptionists",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialities_SpecialityId",
                table: "Doctors",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_AppUserId",
                table: "Doctors",
                column: "AppUserId",
                principalSchema: "auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Appointments_AppointmentId",
                table: "Notes",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecialityId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_AppUserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Appointments_AppointmentId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Receptionists");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AppUserId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5f1ac7a4-30a6-48ea-b85d-1211c1f7ca66");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8c9b308f-f178-4482-af1c-2ddee4f41b8c");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f440851c-8e7e-437e-9823-ea1d603a858d");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HireDate",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Specialities",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "SpecialityId",
                table: "Doctors",
                newName: "SpecialityNum");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_SpecialityId",
                table: "Doctors",
                newName: "IX_Doctors_SpecialityNum");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_AppointmentId",
                table: "Note",
                newName: "IX_Note_AppointmentId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Doctors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Doctors",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Doctors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Ahmad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialities_SpecialityNum",
                table: "Doctors",
                column: "SpecialityNum",
                principalTable: "Specialities",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Appointments_AppointmentId",
                table: "Note",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
