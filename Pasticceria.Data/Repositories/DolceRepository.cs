using System.Linq;
using System.Threading.Tasks;
using Pasticceria.Core.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pasticceria.Core.Repositories;

namespace Pasticceria.Data.Repositories
{
    public class DolceRepository : Repository<Dolce>, IDolceRepository
    {
        public DolceRepository(PasticceriaDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Dolce>> GetAllWithIngredientiAsync()
        {
            return await PasticceriaDbContext.Dolci
                .Select(x => new Dolce 
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Prezzo = x.Prezzo,
                    Quantita = x.Quantita,
                    Data_Inserimento = x.Data_Inserimento,
                    IngredientiOfDolce = PasticceriaDbContext.IngredientiOfDolci.Where(d => d.IdDolce == x.Id).ToList()
                })
                .ToListAsync();
        }

        public Task<Dolce> GetWithIngredientiByIdAsync(int id)
        {
            return PasticceriaDbContext.Dolci
                .Include(i => i.IngredientiOfDolce)
                .ThenInclude(i => i.Ingrediente)
                .SingleOrDefaultAsync(d => d.Id == id);
        }

        private PasticceriaDbContext PasticceriaDbContext
        {
            get { return Context as PasticceriaDbContext; }
        }
    }
}
