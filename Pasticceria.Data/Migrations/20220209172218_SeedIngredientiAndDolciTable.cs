using Microsoft.EntityFrameworkCore.Migrations;

namespace Pasticceria.Data.Migrations
{
    public partial class SeedIngredientiAndDolciTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Ingredienti (Nome) Values ('Zucchero')");
            migrationBuilder
                .Sql("INSERT INTO Ingredienti (Nome) Values ('Farina')");
            migrationBuilder
                .Sql("INSERT INTO Ingredienti (Nome) Values ('Lievito')");
            migrationBuilder
                .Sql("INSERT INTO Ingredienti (Nome) Values ('Uova')");
            migrationBuilder
                .Sql("INSERT INTO Ingredienti (Nome) Values ('Burro')");

            migrationBuilder
                .Sql("INSERT INTO Dolci (Nome, Quantita, Prezzo, Data_Inserimento) Values ('Pasticciotto', 10, 1.50,  '2022-02-06 13:00:00')");

            migrationBuilder
                .Sql("INSERT INTO IngredientiOfDolce (IdDolce, Quantita, IdIngrediente, UnitaDiMisura) values ((SELECT Id FROM Dolci WHERE Nome = 'Pasticciotto'), 200, (SELECT Id FROM Ingredienti WHERE Nome = 'Zucchero'), 'grammi')");
            migrationBuilder
                .Sql("INSERT INTO IngredientiOfDolce (IdDolce, Quantita, IdIngrediente, UnitaDiMisura) values ((SELECT Id FROM Dolci WHERE Nome = 'Pasticciotto'), 4, (SELECT Id FROM Ingredienti WHERE Nome = 'Uova'), 'uova')");
            migrationBuilder
                .Sql("INSERT INTO IngredientiOfDolce (IdDolce, Quantita, IdIngrediente, UnitaDiMisura) values ((SELECT Id FROM Dolci WHERE Nome = 'Pasticciotto'), 250, (SELECT Id FROM Ingredienti WHERE Nome = 'Burro'), 'grammi')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM Dolci");

            migrationBuilder
                .Sql("DELETE FROM Ingredienti");

            migrationBuilder
                .Sql("DELETE FROM IngredientiOfDolce");
        }
    }
}
