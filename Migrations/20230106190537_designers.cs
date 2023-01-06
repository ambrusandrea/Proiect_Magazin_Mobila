using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Magazin_Mobila.Migrations
{
    public partial class designers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Furniture",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "DesignerID",
                table: "Furniture",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Designer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Furniture_DesignerID",
                table: "Furniture",
                column: "DesignerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Furniture_Designer_DesignerID",
                table: "Furniture",
                column: "DesignerID",
                principalTable: "Designer",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furniture_Designer_DesignerID",
                table: "Furniture");

            migrationBuilder.DropTable(
                name: "Designer");

            migrationBuilder.DropIndex(
                name: "IX_Furniture_DesignerID",
                table: "Furniture");

            migrationBuilder.DropColumn(
                name: "DesignerID",
                table: "Furniture");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Furniture",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
