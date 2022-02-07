using Pasticceria.Core.Models;
using Pasticceria.Core.Repositories;

namespace Pasticceria.Data.Repositories
{
    public class IngredienteRepository : Repository<Ingrediente>, IIngredienteRepository
    {
        public IngredienteRepository(PasticceriaDbContext context)
            : base(context)
        { }

        private PasticceriaDbContext PasticceriaDbContext
        {
            get { return Context as PasticceriaDbContext; }
        }
    }
}
