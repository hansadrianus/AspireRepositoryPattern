using Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<TSource> : IRepositoryBase<TSource> where TSource : class
    {
        protected readonly IApplicationContext _context;
        protected readonly IDistributedCache _distCache;
        private readonly IConfiguration _configuration;

        public RepositoryBase(IApplicationContext context, IDistributedCache distCache, IConfiguration configuration)
        {
            _context = context;
            _distCache = distCache;
            _configuration = configuration;
        }

        public virtual void Add(TSource entity)
            => _context.Set<TSource>().Add(entity);

        public virtual async Task AddAsync(TSource entity, CancellationToken cancellationToken = default)
            => await _context.Set<TSource>().AddAsync(entity, cancellationToken);

        public virtual void AddRange(IEnumerable<TSource> entities)
            => _context.Set<TSource>().AddRange(entities);

        public virtual async Task AddRangeAsync(IEnumerable<TSource> entities, CancellationToken cancellationToken = default)
            => await _context.Set<TSource>().AddRangeAsync(entities, cancellationToken);

        public virtual TSource Get(Expression<Func<TSource, bool>> expression)
            => GetSetCacheData().FirstOrDefault(expression);

        public virtual async Task<TSource> GetAsync(Expression<Func<TSource, bool>> expression, CancellationToken cancellationToken = default)
            => await GetSetCacheData().FirstOrDefaultAsync(expression, cancellationToken);

        public virtual TSource GetByDescending<TKey>(Expression<Func<TSource, bool>> expression, Expression<Func<TSource, TKey>> key)
            => GetSetCacheData().OrderByDescending(key).FirstOrDefault(expression);

        public virtual async Task<TSource> GetByDescendingAsync<TKey>(Expression<Func<TSource, bool>> expression, Expression<Func<TSource, TKey>> key, CancellationToken cancellationToken = default)
            => await GetSetCacheData().OrderByDescending(key).FirstOrDefaultAsync(expression, cancellationToken);

        public virtual TSource GetLast<TKey>(Expression<Func<TSource, TKey>> key)
            => GetSetCacheData().OrderBy(key).LastOrDefault();

        public virtual TSource GetLast<TKey>(Expression<Func<TSource, bool>> expression, Expression<Func<TSource, TKey>> key)
            => GetSetCacheData().Where(expression).OrderBy(key).LastOrDefault();

        public virtual TSource GetLastByDescending<TKey>(Expression<Func<TSource, TKey>> key)
            => GetSetCacheData().OrderByDescending(key).LastOrDefault();

        public virtual TSource GetLastByDescending<TKey>(Expression<Func<TSource, bool>> expression, Expression<Func<TSource, TKey>> key)
            => GetSetCacheData().Where(expression).OrderByDescending(key).LastOrDefault();

        public virtual async Task<TSource> GetLastAsync<TKey>(Expression<Func<TSource, TKey>> key, CancellationToken cancellationToken = default)
            => await GetSetCacheData().OrderBy(key).LastOrDefaultAsync(cancellationToken);

        public virtual async Task<TSource> GetLastAsync<TKey>(Expression<Func<TSource, bool>> expression, Expression<Func<TSource, TKey>> key, CancellationToken cancellationToken = default)
            => await GetSetCacheData().Where(expression).OrderBy(key).LastOrDefaultAsync(cancellationToken);

        public virtual async Task<TSource> GetLastByDescendingAsync<TKey>(Expression<Func<TSource, TKey>> key, CancellationToken cancellationToken = default)
            => await GetSetCacheData().OrderByDescending(key).LastOrDefaultAsync(cancellationToken);

        public virtual async Task<TSource> GetLastByDescendingAsync<TKey>(Expression<Func<TSource, bool>> expression, Expression<Func<TSource, TKey>> key, CancellationToken cancellationToken = default)
            => await GetSetCacheData().Where(expression).OrderByDescending(key).LastOrDefaultAsync(cancellationToken);

        public virtual IEnumerable<TSource> GetAll()
            => GetSetCacheData();

        public virtual IEnumerable<TSource> GetAll(Expression<Func<TSource, bool>> expression)
            => GetSetCacheData().Where(expression).AsEnumerable();

        public virtual IEnumerable<TSource> GetAll<TKey>(Expression<Func<TSource, TKey>> key)
            => GetSetCacheData().OrderBy(key).AsEnumerable();

        public virtual IEnumerable<TSource> GetAll<TKey>(Expression<Func<TSource, bool>> expression, Expression<Func<TSource, TKey>> key)
            => GetSetCacheData().Where(expression).OrderBy(key).AsEnumerable();

        public virtual IEnumerable<TSource> GetAllByDescending()
            => GetSetCacheData().Reverse().AsEnumerable();

        public virtual IEnumerable<TSource> GetAllByDescending(Expression<Func<TSource, bool>> expression)
            => GetSetCacheData().Where(expression).Reverse().AsEnumerable();

        public virtual IEnumerable<TSource> GetAllByDescending<TKey>(Expression<Func<TSource, TKey>> key)
            => GetSetCacheData().OrderByDescending(key).AsEnumerable();

        public virtual IEnumerable<TSource> GetAllByDescending<TKey>(Expression<Func<TSource, bool>> expression, Expression<Func<TSource, TKey>> key)
            => GetSetCacheData().Where(expression).OrderByDescending(key).AsEnumerable();

        public virtual async Task<IEnumerable<TSource>> GetAllAsync(CancellationToken cancellationToken = default)
            => await GetSetCacheData().ToListAsync(cancellationToken);

        public virtual async Task<IEnumerable<TSource>> GetAllAsync(Expression<Func<TSource, bool>> expression, CancellationToken cancellationToken = default)
            => await GetSetCacheData().Where(expression).ToListAsync(cancellationToken);

        public virtual async Task<IEnumerable<TSource>> GetAllAsync<TKey>(Expression<Func<TSource, TKey>> key, CancellationToken cancellationToken = default)
            => await GetSetCacheData().OrderBy(key).ToListAsync(cancellationToken);

        public virtual async Task<IEnumerable<TSource>> GetAllAsync<TKey>(Expression<Func<TSource, bool>> expression, Expression<Func<TSource, TKey>> key, CancellationToken cancellationToken = default)
            => await GetSetCacheData().Where(expression).OrderBy(key).ToListAsync(cancellationToken);

        public virtual async Task<IEnumerable<TSource>> GetAllByDescendingAsync(CancellationToken cancellationToken = default)
            => await GetSetCacheData().Reverse().ToListAsync(cancellationToken);

        public virtual async Task<IEnumerable<TSource>> GetAllByDescendingAsync(Expression<Func<TSource, bool>> expression, CancellationToken cancellationToken = default)
            => await GetSetCacheData().Where(expression).Reverse().ToListAsync(cancellationToken);

        public virtual async Task<IEnumerable<TSource>> GetAllByDescendingAsync<TKey>(Expression<Func<TSource, TKey>> key, CancellationToken cancellationToken = default)
            => await GetSetCacheData().OrderByDescending(key).ToListAsync(cancellationToken);

        public virtual async Task<IEnumerable<TSource>> GetAllByDescendingAsync<TKey>(Expression<Func<TSource, bool>> expression, Expression<Func<TSource, TKey>> key, CancellationToken cancellationToken = default)
            => await GetSetCacheData().Where(expression).OrderByDescending(key).ToListAsync(cancellationToken);

        public virtual void Remove(TSource entity)
            => _context.Set<TSource>().Remove(entity);

        public virtual void RemoveRange(IEnumerable<TSource> entities)
            => _context.Set<TSource>().RemoveRange(entities);

        public virtual void Update(TSource entity)
            => _context.Set<TSource>().Update(entity);

        public virtual void UpdateRange(IEnumerable<TSource> entities)
            => _context.Set<TSource>().UpdateRange(entities);

        public IQueryable<TSource> GetSetCacheData()
        {
            IQueryable<TSource> data;
            var cacheKey = typeof(TSource).Name;
            var cacheData = _distCache.GetString(cacheKey);

            if (string.IsNullOrEmpty(cacheData))
            {
                data = _context.Set<TSource>();
                cacheData = JsonSerializer.Serialize(data);
                var opt = GetCacheOptions();
                _distCache.SetString(cacheKey, cacheData, opt);
            }

            data = JsonSerializer.Deserialize<IQueryable<TSource>>(cacheData);

            return data;
        }

        public async Task<IQueryable<TSource>> GetSetCacheDataAsync()
        {
            IQueryable<TSource> data;
            var cacheKey = typeof(TSource).Name;
            var cacheData = await _distCache.GetStringAsync(cacheKey);

            if (string.IsNullOrEmpty(cacheData))
            {
                data = _context.Set<TSource>();
                cacheData = JsonSerializer.Serialize(data);
                var opt = GetCacheOptions();
                await _distCache.SetStringAsync(cacheKey, cacheData, opt);
            }

            data = JsonSerializer.Deserialize<IQueryable<TSource>>(cacheData);

            return data;
        }

        private DistributedCacheEntryOptions GetCacheOptions()
            => new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["RedisCacheOptions:AbsoluteExpirationInMinutes"])))
                .SetSlidingExpiration(TimeSpan.FromMinutes(Convert.ToInt32(_configuration["RedisCacheOptions:SlidingExpirationInMinutes"])));
    }
}
