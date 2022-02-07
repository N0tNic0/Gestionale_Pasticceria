using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pasticceria.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dolci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quantita = table.Column<int>(type: "int", nullable: false),
                    Prezzo = table.Column<double>(type: "float", maxLength: 255, nullable: false),
                    Data_Inserimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dolci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredienti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredienti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientiOfDolce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDolce = table.Column<int>(type: "int", nullable: false),
                    Quantita = table.Column<float>(type: "real", nullable: false),
                    IdIngrediente = table.Column<int>(type: "int", nullable: false),
                    UnitaDiMisura = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientiOfDolce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientiOfDolce_Dolci_IdDolce",
                        column: x => x.IdDolce,
                        principalTable: "Dolci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientiOfDolce_Ingredienti_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "Ingredienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientiOfDolce_IdDolce",
                table: "IngredientiOfDolce",
                column: "IdDolce");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientiOfDolce_IdIngrediente",
                table: "IngredientiOfDolce",
                column: "IdIngrediente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientiOfDolce");

            migrationBuilder.DropTable(
                name: "Dolci");

            migrationBuilder.DropTable(
                name: "Ingredienti");
        }
    }
}
