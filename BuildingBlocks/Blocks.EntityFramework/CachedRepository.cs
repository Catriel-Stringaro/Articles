using Blocks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Blocks.Core.Cache;

namespace Blocks.EntityFrameworkCore;
/// <summary>
/// 
/// </summary>
/// <typeparam name="TDbContext"> is our dbContext </typeparam>
/// <typeparam name="TEntity">our entity, we need to specify which entity are loading using a particular instance of the cache repository </typeparam>
/// <typeparam name="TId"></typeparam>
/// <param name="_dbContext"></param>
/// <param name="_cache">for simplicity we use IMemoryCache is part of.net </param>
public class CachedRepository<TDbContext, TEntity, TId>(TDbContext _dbContext, IMemoryCache _cache)
    where TDbContext : DbContext
    where TEntity : class, IEntity<TId>, ICacheable
    where TId : struct
{
    public IEnumerable<TEntity> GetAll()
        => _cache.GetOrCreateByType(entry => _dbContext.Set<TEntity>().AsNoTracking().ToList())!;
    public TEntity GetById(TId id)
        => GetAll().Single(e => e.Id.Equals(id));
}
