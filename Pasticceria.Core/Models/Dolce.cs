using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pasticceria.Core.Models
{
    public class Dolce
    {
        public Dolce()
        {
            IngredientiOfDolce = new Collection<IngredientiOfDolce>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantita { get; set; }
        public double Prezzo { get; set; }
        public DateTime Data_Inserimento { get; set; }
        public ICollection<IngredientiOfDolce> IngredientiOfDolce { get; set; }
    }
}
