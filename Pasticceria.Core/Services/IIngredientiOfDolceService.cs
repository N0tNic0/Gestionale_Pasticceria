using System.Threading.Tasks;
using Pasticceria.Core.Models;
using System.Collections.Generic;

namespace Pasticceria.Core.Services
{
    public interface IIngredientiOfDolceService
    {
        Task DeleteIngredienteOfDolce(IngredientiOfDolce ingrediente);
        Task<IngredientiOfDolce> GetIngredienteOfDolceById(int id);
        Task<IEnumerable<IngredientiOfDolce>> GetAllIngredientiOfDolci();
        Task<IngredientiOfDolce> CreateIngredienteOfDolce(IngredientiOfDolce newIngredienteOfDolce);
        Task UpdateIngredienteOfDolce(IngredientiOfDolce ingredienteOfdolceToUpdate, IngredientiOfDolce ingredienteOfDolce);
    }
}
