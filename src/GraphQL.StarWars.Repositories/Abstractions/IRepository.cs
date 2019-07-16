using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.StarWars.Repositories.Abstractions
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(params string[] includes);

        Task<TEntity> GetAsync(TKey id, params string[] includes);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> DeleteAsync(TKey id);
        Task  UpdateAsync(TEntity entity);
    }
}