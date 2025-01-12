using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Case.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommnetModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserRate",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 11, 9, 36, 26, 396, DateTimeKind.Utc).AddTicks(290), new DateTime(2025, 1, 11, 9, 36, 26, 396, DateTimeKind.Utc).AddTicks(280) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRate",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 8, 19, 20, 11, 682, DateTimeKind.Utc).AddTicks(4390), new DateTime(2025, 1, 8, 19, 20, 11, 682, DateTimeKind.Utc).AddTicks(4390) });
        }
    }
}
