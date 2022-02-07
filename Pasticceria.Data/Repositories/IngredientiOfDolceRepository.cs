using System.Threading.Tasks;
using Pasticceria.Core.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pasticceria.Core.Repositories;

namespace Pasticceria.Data.Repositories
{
    public class IngredientiOfDolceRepository : Repository<IngredientiOfDolce>, IIngredientiOfDolceRepository
    {
        public IngredientiOfDolceRepository(PasticceriaDbContext context)
            : base(context)
        { }

        public Task<IngredientiOfDolce> GetWithIngredientiAndDolceByIdAsync(int id)
        {
            return PasticceriaDbContext.IngredientiOfDolci
                .Include(i => i.Ingrediente)
                .Include(d => d.Dolce)
                .SingleOrDefaultAsync(iOD => iOD.Id == id);
        }

        public async Task<IEnumerable<IngredientiOfDolce>> GetAllWithIngredientiAndDolceAsync()
        {
            return await PasticceriaDbContext.IngredientiOfDolci
                .Include(i => i.Ingrediente)
                .Include(d => d.Dolce)
                .ToListAsync();
        }

        private PasticceriaDbContext PasticceriaDbContext
        {
            get { return Context as PasticceriaDbContext; }
        }
    }
}
