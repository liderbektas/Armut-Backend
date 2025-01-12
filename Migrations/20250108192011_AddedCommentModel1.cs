using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Case.Migrations
{
    /// <inheritdoc />
    public partial class AddedCommentModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rate",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Rate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 8, 19, 20, 11, 682, DateTimeKind.Utc).AddTicks(4390), null, new DateTime(2025, 1, 8, 19, 20, 11, 682, DateTimeKind.Utc).AddTicks(4390) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 8, 10, 1, 27, 711, DateTimeKind.Utc).AddTicks(9510), new DateTime(2025, 1, 8, 10, 1, 27, 711, DateTimeKind.Utc).AddTicks(9510) });
        }
    }
}
