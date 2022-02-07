using System.Threading.Tasks;
using Pasticceria.Core.Models;
using System.Collections.Generic;

namespace Pasticceria.Core.Repositories
{
    public interface IDolceRepository : IRepository<Dolce>
    {
        Task<Dolce> GetWithIngredientiByIdAsync(int id);
        Task<IEnumerable<Dolce>> GetAllWithIngredientiAsync();
    }
}
