using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Magazin_Mobila.Migrations
{
    public partial class categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Furniture",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Furniture_CategoryID",
                table: "Furniture",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Furniture_Category_CategoryID",
                table: "Furniture",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furniture_Category_CategoryID",
                table: "Furniture");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Furniture_CategoryID",
                table: "Furniture");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Furniture");
        }
    }
}
