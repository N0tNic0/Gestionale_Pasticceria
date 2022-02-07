using System.Threading.Tasks;
using Pasticceria.Core.Models;
using System.Collections.Generic;

namespace Pasticceria.Core.Services
{
    public interface IDolceService
    {
        Task DeleteDolce(Dolce dolce);
        Task<Dolce> GetDolceById(int id);
        Task<IEnumerable<Dolce>> GetAllDolci();
        Task<Dolce> CreateDolce(Dolce newDolce);
        Task UpdateDolce(Dolce dolceToUpdate, Dolce dolce);
    }
}
