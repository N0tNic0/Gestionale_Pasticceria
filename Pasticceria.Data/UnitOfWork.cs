using Pasticceria.Core;
using System.Threading.Tasks;
using Pasticceria.Core.Repositories;
using Pasticceria.Data.Repositories;

namespace Pasticceria.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PasticceriaDbContext _context;
        private IngredienteRepository _ingredienteRepository;
        private DolceRepository _dolceRepository;
        private IngredientiOfDolceRepository _ingredientiOfDolceRepository;

        public UnitOfWork(PasticceriaDbContext context)
        {
            this._context = context;
        }

        public IIngredienteRepository Ingredienti => _ingredienteRepository ?? new IngredienteRepository(_context);

        public IDolceRepository Dolci => _dolceRepository ?? new DolceRepository(_context);

        public IIngredientiOfDolceRepository IngredientiOfDolce => _ingredientiOfDolceRepository ?? new IngredientiOfDolceRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
