using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi.Core;
using WebApi.Store;
namespace webapiassignment.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    bookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    edition = table.Column<string>(nullable: true),
                    barcode = table.Column<string>(nullable: true),
                    copycount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.bookId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    studentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    fine = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "studentbooks",
                columns: table => new
                {
                    bookId = table.Column<int>(nullable: false),
                    studentId = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    hdd = table.Column<int>(nullable: false),
                    bookbarcode = table.Column<string>(nullable: true),
                    issuedate = table.Column<DateTime>(nullable: false),
                    returneDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentbooks", x => new { x.studentId, x.bookId });
                    table.ForeignKey(
                        name: "FK_studentbooks_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentbooks_Students_id",
                        column: x => x.id,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentbooks_bookId",
                table: "studentbooks",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_studentbooks_id",
                table: "studentbooks",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentbooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
