using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreManagementSystem.Data.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Cities_CityId",
                table: "Stores");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Cities_CityId",
                table: "Stores",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Cities_CityId",
                table: "Stores");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Cities_CityId",
                table: "Stores",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
