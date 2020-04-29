using Announcer.Contracts;
using Announcer.Data.Contexts;
using Announcer.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Announcer.Data.Repositories
{
    /// <summary>
    /// Generic repository
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly AnnouncerDbContext _dbContext;

        public Repository(AnnouncerDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <inheritdoc/>
        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        /// <inheritdoc/>
        public async Task<long> CountAsync(Expression<Func<T, bool>> predicate = null, bool includeDeleted = false)
        {
            return await GetQueryable(includeDeleted).ApplyCriteria(predicate, null, null, "", true).LongCountAsync();
        }

        /// <inheritdoc/>
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        /// <inheritdoc/>
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = false)
        {
            return await GetQueryable(includeDeleted).ApplyCriteria(predicate, null, null, "", true).AnyAsync();
        }

        /// <inheritdoc/>
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, string includeString = "", bool includeDeleted = false)
        {
            return await GetQueryable(includeDeleted).ApplyCriteria(predicate, null, null, includeString, true).SingleOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> ListAllAsync(int? page = null, int? pageSize = null, bool includeDeleted = false)
        {
            return await GetQueryable(includeDeleted).Paging(page, pageSize).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate, int? page = null, int? pageSize = null, bool includeDeleted = false)
        {
            return await GetQueryable(includeDeleted).Where(predicate).Paging(page, pageSize).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate = null,
                                                    Expression<Func<T, object>> groupBy = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                    string includeString = "",
                                                    int? page = null,
                                                    int? pageSize = null,
                                                    bool disableTracking = true,
                                                    bool includeDeleted = false)
        {
            return await GetQueryable(includeDeleted).ApplyCriteria(predicate, groupBy, orderBy, includeString, disableTracking).Paging(page, pageSize).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate = null,
                                                    Expression<Func<T, object>> groupBy = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                    List<Expression<Func<T, object>>> includes = null,
                                                    int? page = null,
                                                    int? pageSize = null,
                                                    bool disableTracking = true,
                                                    bool includeDeleted = false)
        {
            return await GetQueryable(includeDeleted).ApplyCriteria(predicate, groupBy, orderBy, includes, disableTracking).Paging(page, pageSize).ToListAsync();
        }

        /// <inheritdoc/>
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        private IQueryable<T> GetQueryable(bool includeDeleted = false)
        {
            return (includeDeleted) ? _dbContext.Set<T>().IgnoreQueryFilters() : _dbContext.Set<T>();
        }
    }
}