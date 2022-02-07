using System;

namespace Pasticceria.Api.Resources
{
    public class SaveDolceResource
    {
        public string Nome { get; set; }
        public int Quantita { get; set; }
        public double Prezzo { get; set; }
        public DateTime Data_Inserimento { get; set; }
    }
}
