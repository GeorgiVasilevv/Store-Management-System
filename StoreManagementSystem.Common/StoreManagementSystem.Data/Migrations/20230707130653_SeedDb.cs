using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreManagementSystem.Data.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "T-Shirt" });

            migrationBuilder.InsertData(
                table: "ClothesSizes",
                columns: new[] { "Id", "Size" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "ShoesSizes",
                columns: new[] { "Id", "SizeNumber" },
                values: new object[,]
                {
                    { 1, 34 },
                    { 2, 35 },
                    { 3, 36 },
                    { 4, 37 },
                    { 5, 38 },
                    { 6, 39 },
                    { 7, 40 },
                    { 8, 41 },
                    { 9, 42 },
                    { 10, 43 },
                    { 11, 44 },
                    { 12, 45 },
                    { 13, 46 },
                    { 14, 47 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "DateCreated", "Description", "ImageUrl", "IsDeleted", "OwnerId", "Rating", "Title" },
                values: new object[] { 1, new DateTime(2023, 7, 7, 13, 6, 53, 251, DateTimeKind.Utc).AddTicks(7443), "This store is made for designer's brands", "https://cdn.shopify.com/s/files/1/0635/0815/files/claremont-store-iamge_1000x.jpg?v=1667541605", false, new Guid("f1cca3df-6437-423b-6256-08db7ee9be60"), 0m, "Gosho's store" });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "AvailableQuantity", "CategoryId", "ClothingId", "Condition", "Description", "ImageUrl", "IsDeleted", "Price", "StoreId", "Title" },
                values: new object[] { 1, 4, 1, 1, 0, "Made with 100% cotton", "https://d010205.bibloo.bg/_galerie/varianty/190/1902771-z.jpg", false, 50.99m, 1, "T-Shirt - GUESS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClothesSizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClothesSizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClothesSizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClothesSizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ShoesSizes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClothesSizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
