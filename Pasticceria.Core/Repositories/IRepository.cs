using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Pasticceria.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Remove(TEntity entity);
        Task AddAsync(TEntity entity);
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void RemoveRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
