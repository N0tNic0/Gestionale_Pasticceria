using Pasticceria.Core;
using Pasticceria.Core.Models;
using Pasticceria.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pasticceria.Services
{
    public class DolceService : IDolceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DolceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Dolce> CreateDolce(Dolce newDolce)
        {
            await _unitOfWork.Dolci
                .AddAsync(newDolce);
            await _unitOfWork.CommitAsync();
            return newDolce;
        }

        public async Task DeleteDolce(Dolce dolce)
        {
            _unitOfWork.Dolci.Remove(dolce);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Dolce>> GetAllDolci()
        {
            return await _unitOfWork.Dolci.GetAllWithIngredientiAsync();
        }

        public async Task<Dolce> GetDolceById(int id)
        {
            return await _unitOfWork.Dolci.GetByIdAsync(id);
        }

        public async Task UpdateDolce(Dolce dolceToUpdate, Dolce dolce)
        {
            dolceToUpdate.Nome = dolce.Nome;
            dolceToUpdate.Prezzo = dolce.Prezzo;
            dolceToUpdate.Quantita = dolce.Quantita;
            dolceToUpdate.Data_Inserimento = dolce.Data_Inserimento;
            await _unitOfWork.CommitAsync();
        }
    }
}
