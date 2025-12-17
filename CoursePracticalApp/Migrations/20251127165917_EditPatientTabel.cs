using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoursePracticalApp.Migrations
{
    /// <inheritdoc />
    public partial class EditPatientTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Patients",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "Patients",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()");

            migrationBuilder.AddColumn<string>(
                name: "EmgContactName",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmgContactPhone",
                table: "Patients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasConsentData",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasConsentTreatment",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasInsurance",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceNumber",
                table: "Patients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InsuranceProvider",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReceptionistId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ValidFrom",
                table: "Patients",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "ValidTo",
                table: "Patients",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2dc69b65-46fa-48fb-8187-e0ddacbe1353", "8379348a-b161-47c2-873a-b3f1e62009c8", "DOCTOR", "DOCTOR" },
                    { "3df21187-6d7a-4e55-9833-178f8e424b7e", "37267b18-d873-48a0-94eb-c836d67b1314", "RECEPTIONEST", "RECEPTIONEST" },
                    { "afe734b1-e0b1-47bb-9891-2833c77476fe", "c8499bda-2cbd-4fe0-addf-de3b70d3a3a7", "APP_ADMIN", "APP_ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ReceptionistId",
                table: "Patients",
                column: "ReceptionistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Receptionists_ReceptionistId",
                table: "Patients",
                column: "ReceptionistId",
                principalTable: "Receptionists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Receptionists_ReceptionistId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ReceptionistId",
                table: "Patients");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2dc69b65-46fa-48fb-8187-e0ddacbe1353");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3df21187-6d7a-4e55-9833-178f8e424b7e");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "afe734b1-e0b1-47bb-9891-2833c77476fe");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "EmgContactName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "EmgContactPhone",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HasConsentData",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HasConsentTreatment",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HasInsurance",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "InsuranceNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "InsuranceProvider",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ReceptionistId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Patients",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

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
        }
    }
}
