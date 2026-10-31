using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetManagement.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialSqlServerCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastChecked = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "BorrowedBy", "DeviceType", "LastChecked", "Name", "ReturnDeadline", "Status" },
                values: new object[,]
                {
                    { "AVAIN-01", null, "Avain", new DateTime(2026, 10, 31, 16, 36, 25, 515, DateTimeKind.Utc).AddTicks(1629), "Pääoven kulkulätkä", null, "Vapaa" },
                    { "IPAD-04", "Benjamin Masena", "Tabletti", new DateTime(2026, 10, 31, 16, 36, 25, 515, DateTimeKind.Utc).AddTicks(4920), "Aulan esittelypääte", null, "Lainassa" },
                    { "REITITIN-02", null, "Verkkolaite", new DateTime(2026, 10, 31, 16, 36, 25, 515, DateTimeKind.Utc).AddTicks(5627), "Neuvotteluhuoneen reititin", null, "Huollossa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
