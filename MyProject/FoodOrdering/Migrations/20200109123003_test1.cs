using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrdering.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "FoodItemCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foodname",
                table: "FoodItemCategory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "FoodItemCategory");

            migrationBuilder.DropColumn(
                name: "Foodname",
                table: "FoodItemCategory");
        }
    }
}
