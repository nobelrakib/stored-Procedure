using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrdering.Migrations
{
    public partial class n5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodItemId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_FoodItemId",
                table: "Order",
                column: "FoodItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_FoodItems_FoodItemId",
                table: "Order",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_FoodItems_FoodItemId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_FoodItemId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "FoodItemId",
                table: "Order");
        }
    }
}
