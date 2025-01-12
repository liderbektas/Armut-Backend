using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Case.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJobModelDescripitonNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 31, 8, 46, 45, 730, DateTimeKind.Utc).AddTicks(2250), new DateTime(2024, 12, 31, 8, 46, 45, 730, DateTimeKind.Utc).AddTicks(2240) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 31, 8, 39, 4, 136, DateTimeKind.Utc).AddTicks(60), new DateTime(2024, 12, 31, 8, 39, 4, 136, DateTimeKind.Utc).AddTicks(50) });
        }
    }
}
