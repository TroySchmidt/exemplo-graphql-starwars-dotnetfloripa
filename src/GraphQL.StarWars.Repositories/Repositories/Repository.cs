using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.StarWars.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.StarWars.Repositories.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        private readonly DbContext _dbContext;

        protected Repository()
        {
        }

        protected Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return _dbContext.Set<TEntity>().ToListAsync();
        }

        public Task<List<TEntity>> GetAllAsync(params string[] includes)
        {
            return GetQueryable(includes).ToListAsync();
        }

        public Task<TEntity> GetAsync(TKey id, params string[] includes)
        {
            return GetQueryable(includes).SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteAsync(TKey id)
        {
            _dbContext.Remove(new TEntity {Id = id});
            var entity = new TEntity {Id = id};
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Set<TEntity>().Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        
        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<TEntity> GetQueryable(IEnumerable<string> includes)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable().AsNoTracking();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}