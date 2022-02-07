using System.Threading.Tasks;
using Pasticceria.Core.Models;
using System.Collections.Generic;

namespace Pasticceria.Core.Repositories
{
    public interface IIngredientiOfDolceRepository : IRepository<IngredientiOfDolce>
    {
        Task<IngredientiOfDolce> GetWithIngredientiAndDolceByIdAsync(int id);
        Task<IEnumerable<IngredientiOfDolce>> GetAllWithIngredientiAndDolceAsync();
    }
}
