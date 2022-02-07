using Pasticceria.Core;
using System.Threading.Tasks;
using Pasticceria.Core.Models;
using Pasticceria.Core.Services;
using System.Collections.Generic;

namespace Pasticceria.Services
{
    public class IngredienteService : IIngredienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IngredienteService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Ingrediente> CreateIngrediente(Ingrediente newIngrediente)
        {
            await _unitOfWork.Ingredienti.AddAsync(newIngrediente);
            await _unitOfWork.CommitAsync();
            return newIngrediente;
        }

        public async Task DeleteIngrediente(Ingrediente ingrediente)
        {
            _unitOfWork.Ingredienti.Remove(ingrediente);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Ingrediente>> GetAll()
        {
            return await _unitOfWork.Ingredienti
                .GetAllAsync();
        }

        public async Task<Ingrediente> GetIngredienteById(int id)
        {
            return await _unitOfWork.Ingredienti
                .GetByIdAsync(id);
        }

        public async Task UpdateIngrediente(Ingrediente ingredienteToUpdate, Ingrediente ingrediente)
        {
            ingredienteToUpdate.Nome = ingrediente.Nome;

            await _unitOfWork.CommitAsync();
        }
    }
}
