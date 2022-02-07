using System;
using System.Threading.Tasks;
using Pasticceria.Core.Repositories;

namespace Pasticceria.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
        IDolceRepository Dolci { get; }
        IIngredienteRepository Ingredienti { get; }
        IIngredientiOfDolceRepository IngredientiOfDolce { get; }
    }
}
