using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimedikaTask.Migrations
{
    /// <inheritdoc />
    public partial class MainMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyDetails_Log_LogModelId",
                table: "PharmacyDetails");

            migrationBuilder.DropIndex(
                name: "IX_PharmacyDetails_LogModelId",
                table: "PharmacyDetails");

            migrationBuilder.DropColumn(
                name: "LogId",
                table: "PharmacyDetails");

            migrationBuilder.DropColumn(
                name: "LogModelId",
                table: "PharmacyDetails");

            migrationBuilder.DropColumn(
                name: "LastAccessDate",
                table: "Log");

            migrationBuilder.AddColumn<int>(
                name: "PharmacyId",
                table: "Log",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyId",
                table: "Log");

            migrationBuilder.AddColumn<int>(
                name: "LogId",
                table: "PharmacyDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogModelId",
                table: "PharmacyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAccessDate",
                table: "Log",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyDetails_LogModelId",
                table: "PharmacyDetails",
                column: "LogModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyDetails_Log_LogModelId",
                table: "PharmacyDetails",
                column: "LogModelId",
                principalTable: "Log",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
