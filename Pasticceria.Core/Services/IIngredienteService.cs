using System.Threading.Tasks;
using Pasticceria.Core.Models;
using System.Collections.Generic;

namespace Pasticceria.Core.Services
{
    public interface IIngredienteService
    {
        Task<IEnumerable<Ingrediente>> GetAll();
        Task<Ingrediente> GetIngredienteById(int id);
        Task DeleteIngrediente(Ingrediente ingrediente);
        Task<Ingrediente> CreateIngrediente(Ingrediente newIngrediente);
        Task UpdateIngrediente(Ingrediente ingredienteToUpdate, Ingrediente ingrediente);
    }
}
