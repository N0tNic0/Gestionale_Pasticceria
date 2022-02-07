using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pasticceria.Core.Models
{
    public class Ingrediente
    {
        public Ingrediente()
        {
            IngredientiOfDolce = new Collection<IngredientiOfDolce>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<IngredientiOfDolce> IngredientiOfDolce { get; set; }
    }
}
