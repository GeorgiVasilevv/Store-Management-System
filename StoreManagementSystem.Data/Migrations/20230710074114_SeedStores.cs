using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreManagementSystem.Data.Migrations
{
    public partial class SeedStores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_ClothesSizes_ClothingId",
                table: "Clothes");

            migrationBuilder.RenameColumn(
                name: "ClothingId",
                table: "Clothes",
                newName: "ClothingSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Clothes_ClothingId",
                table: "Clothes",
                newName: "IX_Clothes_ClothingSizeId");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2023, 7, 10, 7, 41, 14, 641, DateTimeKind.Utc).AddTicks(172), "Gosho's designer store" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "DateCreated", "Description", "ImageUrl", "IsDeleted", "OwnerId", "Rating", "Title" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 7, 10, 7, 41, 14, 641, DateTimeKind.Utc).AddTicks(184), "This store has different types of clothing", "https://bigsee.eu/wp-content/uploads/2022/04/DSC4685.jpg", false, new Guid("f1cca3df-6437-423b-6256-08db7ee9be60"), 0m, "Gosho's store" },
                    { 3, new DateTime(2023, 7, 10, 7, 41, 14, 641, DateTimeKind.Utc).AddTicks(186), "This store has different types of sneakers", "https://planomagazine.com/wp-content/uploads/2021/04/Plano-Magazine-Prized-Kicks-sneaker-store-now-open_feature-1170x556.jpg", false, new Guid("f1cca3df-6437-423b-6256-08db7ee9be60"), 0m, "Gosho's sneaker store" },
                    { 4, new DateTime(2023, 7, 10, 7, 41, 14, 641, DateTimeKind.Utc).AddTicks(187), "This store has different types of designer wear", "https://media.architecturaldigest.com/photos/56045fcfcbec99cc0f9f7574/16:9/w_1280,c_limit/dam-images-daily-2014-10-jill-stuart-jill-stuart-soho.jpg", false, new Guid("96521533-2970-4085-b6d0-08db81187eb1"), 0m, "Vanko's designer store" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_ClothesSizes_ClothingSizeId",
                table: "Clothes",
                column: "ClothingSizeId",
                principalTable: "ClothesSizes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_ClothesSizes_ClothingSizeId",
                table: "Clothes");

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "ClothingSizeId",
                table: "Clothes",
                newName: "ClothingId");

            migrationBuilder.RenameIndex(
                name: "IX_Clothes_ClothingSizeId",
                table: "Clothes",
                newName: "IX_Clothes_ClothingId");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2023, 7, 7, 13, 7, 11, 30, DateTimeKind.Utc).AddTicks(5561), "Gosho's store" });

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_ClothesSizes_ClothingId",
                table: "Clothes",
                column: "ClothingId",
                principalTable: "ClothesSizes",
                principalColumn: "Id");
        }
    }
}
