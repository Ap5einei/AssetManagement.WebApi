using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class FixDeterministicModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: "AVAIN-01",
                column: "LastChecked",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: "IPAD-04",
                column: "LastChecked",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: "REITITIN-02",
                column: "LastChecked",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: "AVAIN-01",
                column: "LastChecked",
                value: new DateTime(2026, 10, 31, 16, 36, 25, 515, DateTimeKind.Utc).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: "IPAD-04",
                column: "LastChecked",
                value: new DateTime(2026, 10, 31, 16, 36, 25, 515, DateTimeKind.Utc).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: "REITITIN-02",
                column: "LastChecked",
                value: new DateTime(2026, 10, 31, 16, 36, 25, 515, DateTimeKind.Utc).AddTicks(5627));
        }
    }
}
