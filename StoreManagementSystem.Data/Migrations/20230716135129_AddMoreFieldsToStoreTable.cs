using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreManagementSystem.Data.Migrations
{
    public partial class AddMoreFieldsToStoreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Sofia" },
                    { 2, "Plovdiv" },
                    { 3, "Varna" },
                    { 4, "Burgas" },
                    { 5, "Ruse" },
                    { 6, "Stara Zagora" },
                    { 7, "Pleven" },
                    { 8, "Sliven" },
                    { 9, "Pazardzhik" },
                    { 10, "Pernik" },
                    { 11, "Dobrich" },
                    { 12, "Shumen" },
                    { 13, "Veliko Tarnovo" },
                    { 14, "Haskovo" },
                    { 15, "Blagoevgrad" },
                    { 16, "Yambol" },
                    { 17, "Kazanlak" },
                    { 18, "Asenovgrad" },
                    { 19, "Vratsa" },
                    { 20, "Kyustendil" },
                    { 21, "Gabrovo" },
                    { 22, "Targovishte" },
                    { 23, "Kardzhali" },
                    { 24, "Vidin" },
                    { 25, "Razgrad" },
                    { 26, "Svishtov" },
                    { 27, "Silistra" },
                    { 28, "Lovech" },
                    { 29, "Montana" },
                    { 30, "Dimitrovgrad" },
                    { 31, "Dupnitsa" },
                    { 32, "Smolyan" },
                    { 33, "Gorna Oryahovitsa" },
                    { 34, "Petrich" },
                    { 35, "Gotse Delchev" },
                    { 36, "Aytos" },
                    { 37, "Omurtag" },
                    { 38, "Velingrad" },
                    { 39, "Karlovo" },
                    { 40, "Lom" },
                    { 41, "Panagyurishte" },
                    { 42, "Botevgrad" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 43, "Peshtera" },
                    { 44, "Rakovski" },
                    { 45, "Pomorie" },
                    { 46, "Novi Pazar" },
                    { 47, "Provadia" },
                    { 48, "Zlatograd" },
                    { 49, "Kozloduy" },
                    { 50, "Bankya" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Blagoevgrad" },
                    { 2, "Burgas" },
                    { 3, "Dobrich" },
                    { 4, "Gabrovo" },
                    { 5, "Haskovo" },
                    { 6, "Kardzhali" },
                    { 7, "Kyustendil" },
                    { 8, "Lovech" },
                    { 9, "Montana" },
                    { 10, "Pazardzhik" },
                    { 11, "Pernik" },
                    { 12, "Pleven" },
                    { 13, "Plovdiv" },
                    { 14, "Razgrad" },
                    { 15, "Ruse" },
                    { 16, "Shumen" },
                    { 17, "Silistra" },
                    { 18, "Sliven" },
                    { 19, "Smolyan" },
                    { 20, "Sofia City" },
                    { 21, "Sofia (province)" },
                    { 22, "Stara Zagora" },
                    { 23, "Targovishte" },
                    { 24, "Varna" },
                    { 25, "Veliko Tarnovo" },
                    { 26, "Vidin" },
                    { 27, "Vratsa" },
                    { 28, "Yambol" }
                });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CityId", "DateCreated", "ProvinceId" },
                values: new object[] { "ul. Petko R. Slaveikov 36", 22, new DateTime(2023, 7, 16, 13, 51, 29, 503, DateTimeKind.Utc).AddTicks(5340), 23 });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CityId", "DateCreated", "ProvinceId" },
                values: new object[] { "ul. Asen Hristoforov 6", 2, new DateTime(2023, 7, 16, 13, 51, 29, 503, DateTimeKind.Utc).AddTicks(5354), 13 });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CityId", "DateCreated", "ProvinceId" },
                values: new object[] { "bul. Cherni Vrah 47", 1, new DateTime(2023, 7, 16, 13, 51, 29, 503, DateTimeKind.Utc).AddTicks(5357), 20 });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "CityId", "DateCreated", "ProvinceId" },
                values: new object[] { "ul. Mara Buneva 52", 1, new DateTime(2023, 7, 16, 13, 51, 29, 503, DateTimeKind.Utc).AddTicks(5358), 20 });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_CityId",
                table: "Stores",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_ProvinceId",
                table: "Stores",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Cities_CityId",
                table: "Stores",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Provinces_ProvinceId",
                table: "Stores",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Cities_CityId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Provinces_ProvinceId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Stores_CityId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_ProvinceId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Stores");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 10, 7, 41, 14, 641, DateTimeKind.Utc).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 10, 7, 41, 14, 641, DateTimeKind.Utc).AddTicks(184));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 10, 7, 41, 14, 641, DateTimeKind.Utc).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 10, 7, 41, 14, 641, DateTimeKind.Utc).AddTicks(187));
        }
    }
}
