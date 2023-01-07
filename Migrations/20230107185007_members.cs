using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Magazin_Mobila.Migrations
{
    public partial class members : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: true),
                    FurnitureID = table.Column<int>(type: "int", nullable: true),
                    DesignerID = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Registration_Designer_DesignerID",
                        column: x => x.DesignerID,
                        principalTable: "Designer",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Registration_Furniture_FurnitureID",
                        column: x => x.FurnitureID,
                        principalTable: "Furniture",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Registration_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registration_DesignerID",
                table: "Registration",
                column: "DesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_FurnitureID",
                table: "Registration",
                column: "FurnitureID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_MemberID",
                table: "Registration",
                column: "MemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
