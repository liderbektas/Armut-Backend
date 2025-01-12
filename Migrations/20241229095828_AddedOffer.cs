using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Case.Migrations
{
    /// <inheritdoc />
    public partial class AddedOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 9, 58, 28, 460, DateTimeKind.Utc).AddTicks(8560), new DateTime(2024, 12, 29, 9, 58, 28, 460, DateTimeKind.Utc).AddTicks(8560) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 9, 56, 3, 43, DateTimeKind.Utc).AddTicks(5010), new DateTime(2024, 12, 29, 9, 56, 3, 43, DateTimeKind.Utc).AddTicks(5010) });
        }
    }
}
