using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Magazin_Mobila.Migrations
{
    public partial class furniturematerial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureMaterial",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureID = table.Column<int>(type: "int", nullable: false),
                    MaterialID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureMaterial", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FurnitureMaterial_Furniture_FurnitureID",
                        column: x => x.FurnitureID,
                        principalTable: "Furniture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureMaterial_Material_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Material",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureMaterial_FurnitureID",
                table: "FurnitureMaterial",
                column: "FurnitureID");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureMaterial_MaterialID",
                table: "FurnitureMaterial",
                column: "MaterialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FurnitureMaterial");

            migrationBuilder.DropTable(
                name: "Material");
        }
    }
}
