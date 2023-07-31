using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreManagementSystem.Data.Migrations
{
    public partial class AddFluentAPIRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Provinces_ProvinceId",
                table: "Stores");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Provinces_ProvinceId",
                table: "Stores",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Provinces_ProvinceId",
                table: "Stores");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Provinces_ProvinceId",
                table: "Stores",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
