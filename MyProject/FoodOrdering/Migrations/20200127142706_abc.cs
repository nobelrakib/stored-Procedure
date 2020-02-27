using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrdering.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_FoodItemId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_FoodItemId",
                table: "Order",
                column: "FoodItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_FoodItemId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_FoodItemId",
                table: "Order",
                column: "FoodItemId",
                unique: true);
        }
    }
}
