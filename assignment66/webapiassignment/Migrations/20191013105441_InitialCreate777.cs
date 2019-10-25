using Microsoft.EntityFrameworkCore.Migrations;
using WebApi.Store;
using System;
namespace webapiassignment.Migrations
{
    public partial class InitialCreate777 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentbooks_Students_id",
                table: "studentbooks");

            migrationBuilder.DropIndex(
                name: "IX_studentbooks_id",
                table: "studentbooks");

            migrationBuilder.DropColumn(
                name: "id",
                table: "studentbooks");

            migrationBuilder.AddForeignKey(
                name: "FK_studentbooks_Students_studentId",
                table: "studentbooks",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentbooks_Students_studentId",
                table: "studentbooks");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "studentbooks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_studentbooks_id",
                table: "studentbooks",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_studentbooks_Students_id",
                table: "studentbooks",
                column: "id",
                principalTable: "Students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
