using System;
using System.Collections.Generic;

namespace Pasticceria.Api.Resources
{
    public class DolceResource
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantita { get; set; }
        public double Prezzo { get; set; }
        public DateTime Data_Inserimento { get; set; }
        public ICollection<IngredientiOfDolceCompleteResource> IngredientiOfDolce { get; set; }
    }

    public class IngredientiOfDolceCompleteResource : IngredientiOfDolceResource
    {
        public IngredienteResource Ingrediente { get; set; }
    }
}
