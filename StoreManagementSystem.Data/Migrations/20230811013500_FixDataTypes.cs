using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreManagementSystem.Data.Migrations
{
    public partial class FixDataTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RatingCount",
                table: "Stores",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "RatingCount" },
                values: new object[] { new DateTime(2023, 8, 11, 1, 35, 0, 82, DateTimeKind.Utc).AddTicks(9065), 0m });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "RatingCount" },
                values: new object[] { new DateTime(2023, 8, 11, 1, 35, 0, 82, DateTimeKind.Utc).AddTicks(9079), 0m });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "RatingCount" },
                values: new object[] { new DateTime(2023, 8, 11, 1, 35, 0, 82, DateTimeKind.Utc).AddTicks(9081), 0m });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "RatingCount" },
                values: new object[] { new DateTime(2023, 8, 11, 1, 35, 0, 82, DateTimeKind.Utc).AddTicks(9107), 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RatingCount",
                table: "Stores",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "RatingCount" },
                values: new object[] { new DateTime(2023, 8, 11, 0, 49, 41, 227, DateTimeKind.Utc).AddTicks(7775), 0 });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "RatingCount" },
                values: new object[] { new DateTime(2023, 8, 11, 0, 49, 41, 227, DateTimeKind.Utc).AddTicks(7788), 0 });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "RatingCount" },
                values: new object[] { new DateTime(2023, 8, 11, 0, 49, 41, 227, DateTimeKind.Utc).AddTicks(7790), 0 });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "RatingCount" },
                values: new object[] { new DateTime(2023, 8, 11, 0, 49, 41, 227, DateTimeKind.Utc).AddTicks(7792), 0 });
        }
    }
}
