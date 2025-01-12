using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Case.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommnetModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 11, 10, 4, 29, 190, DateTimeKind.Utc).AddTicks(5810), new DateTime(2025, 1, 11, 10, 4, 29, 190, DateTimeKind.Utc).AddTicks(5800) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 11, 9, 36, 26, 396, DateTimeKind.Utc).AddTicks(290), new DateTime(2025, 1, 11, 9, 36, 26, 396, DateTimeKind.Utc).AddTicks(280) });
        }
    }
}
