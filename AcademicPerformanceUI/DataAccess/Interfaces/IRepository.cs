using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity:IEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<List<TEntity>> GetAllEntitiesAsync();
        void AddCollection(List<TEntity> entities);
        TEntity CreateEmptyObject();
    }
}
