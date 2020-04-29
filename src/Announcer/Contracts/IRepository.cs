using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Announcer.Contracts
{
    /// <summary>
    /// Generic repository interface
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface IRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Adds an entity to context
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Counts entities matching <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Filter to be checked</param>
        /// <param name="includeDeleted">Include soft deleted entities</param>
        /// <returns>Number of entities matching filter</returns>
        Task<long> CountAsync(Expression<Func<T, bool>> predicate = null, bool includeDeleted = false);

        /// <summary>
        /// Deletes an entity from context
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        void Delete(T entity);

        /// <summary>
        /// Checks if entity matching <paramref name="predicate"/> exists at context
        /// </summary>
        /// <param name="predicate">Filter to be checked</param>
        /// <param name="includeDeleted">Include soft deleted entities</param>
        /// <returns>True if an entity exists matching filter, else False</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = false);

        /// <summary>
        /// Gets an entity matching <paramref name="predicate"/> with includes
        /// specified in <paramref name="includeString"/> from context
        /// </summary>
        /// <param name="predicate">Filter to be checked</param>
        /// <param name="includeString">Include properties as string seperated with comma</param>
        /// <param name="includeDeleted">Include soft deleted entities</param>
        /// <returns>Entity matching filter with included properties</returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, string includeString = "", bool includeDeleted = false);

        /// <summary>
        /// Lists all entities with paging support from context
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="includeDeleted">Include soft deleted entities</param>
        /// <returns>Paged list of all entities</returns>
        Task<IEnumerable<T>> ListAllAsync(int? page = null, int? pageSize = null, bool includeDeleted = false);

        /// <summary>
        /// Lists entities matching <paramref name="predicate"/> with paging support from context
        /// </summary>
        /// <param name="predicate">Filter to be checked</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="includeDeleted">Include soft deleted entities</param>
        /// <returns>Paged list of entities matching filter</returns>
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate, int? page = null, int? pageSize = null, bool includeDeleted = false);

        /// <summary>
        /// Lists entities matching <paramref name="predicate"/> with grouping, ordering, including and paging support
        /// </summary>
        /// <param name="predicate">Filter to be checked</param>
        /// <param name="groupBy">Grouping expression</param>
        /// <param name="orderBy">Ordering expression</param>
        /// <param name="includeString">Include properties as string seperated with comma</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="disableTracking">Disable tracking parameter</param>
        /// <param name="includeDeleted">Include soft deleted entities</param>
        /// <returns>Paged list of entities matching filter</returns>
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate = null,
                                       Expression<Func<T, object>> groupBy = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       string includeString = "",
                                       int? page = null,
                                       int? pageSize = null,
                                       bool disableTracking = true,
                                       bool includeDeleted = false);

        /// <summary>
        /// Lists entities matching <paramref name="predicate"/> with grouping, ordering, including and paging support
        /// </summary>
        /// <param name="predicate">Filter to be checked</param>
        /// <param name="groupBy">Grouping expression</param>
        /// <param name="orderBy">Ordering expression</param>
        /// <param name="includes">Include expression</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="disableTracking">Disable tracking parameter</param>
        /// <param name="includeDeleted">Include soft deleted entities</param>
        /// <returns>Paged list of entities matching filter</returns>
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate = null,
                                       Expression<Func<T, object>> groupBy = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       List<Expression<Func<T, object>>> includes = null,
                                       int? page = null,
                                       int? pageSize = null,
                                       bool disableTracking = true,
                                       bool includeDeleted = false);

        /// <summary>
        /// Updates an entity at context
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        void Update(T entity);
    }
}