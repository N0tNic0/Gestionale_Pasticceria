using Pasticceria.Core;
using System.Threading.Tasks;
using Pasticceria.Core.Models;
using Pasticceria.Core.Services;
using System.Collections.Generic;

namespace Pasticceria.Services
{
    public class IngredientiOfDolceService : IIngredientiOfDolceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IngredientiOfDolceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IngredientiOfDolce> CreateIngredienteOfDolce(IngredientiOfDolce newIngredienteOfDolce)
        {
            await _unitOfWork.IngredientiOfDolce.AddAsync(newIngredienteOfDolce);
            await _unitOfWork.CommitAsync();
            return newIngredienteOfDolce;
        }

        public async Task DeleteIngredienteOfDolce(IngredientiOfDolce ingrediente)
        {
            _unitOfWork.IngredientiOfDolce.Remove(ingrediente);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<IngredientiOfDolce>> GetAllIngredientiOfDolci()
        {
            return await _unitOfWork.IngredientiOfDolce
                .GetAllWithIngredientiAndDolceAsync();
        }

        public async Task<IngredientiOfDolce> GetIngredienteOfDolceById(int id)
        {
            return await _unitOfWork.IngredientiOfDolce
                .GetWithIngredientiAndDolceByIdAsync(id);
        }

        public async Task UpdateIngredienteOfDolce(IngredientiOfDolce ingredienteOfdolceToUpdate, IngredientiOfDolce ingredienteOfDolce)
        {
            ingredienteOfdolceToUpdate.Quantita = ingredienteOfDolce.Quantita;
            ingredienteOfdolceToUpdate.UnitaDiMisura = ingredienteOfDolce.UnitaDiMisura;
            ingredienteOfdolceToUpdate.IdDolce = ingredienteOfDolce.IdDolce;
            ingredienteOfdolceToUpdate.IdIngrediente = ingredienteOfDolce.IdIngrediente;

            await _unitOfWork.CommitAsync();
        }
    }
}
