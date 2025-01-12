using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Case.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRequestModal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 12, 1, 6, 103, DateTimeKind.Utc).AddTicks(1430), new DateTime(2025, 1, 1, 12, 1, 6, 103, DateTimeKind.Utc).AddTicks(1420) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 31, 8, 46, 45, 730, DateTimeKind.Utc).AddTicks(2250), new DateTime(2024, 12, 31, 8, 46, 45, 730, DateTimeKind.Utc).AddTicks(2240) });
        }
    }
}
