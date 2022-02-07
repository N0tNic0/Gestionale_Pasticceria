
namespace Pasticceria.Core.Models
{
    public class IngredientiOfDolce
    {
        public int Id { get; set; }
        public int IdDolce { get; set; }
        public float Quantita { get; set; }
        public int IdIngrediente { get; set; }
        public string UnitaDiMisura { get; set; }

        public Dolce Dolce { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
