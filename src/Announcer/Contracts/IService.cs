using Announcer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Announcer.Contracts
{
    /// <summary>
    /// Generic service interface
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface IService<T> where T : class, IEntity
    {
        /// <summary>
        /// Adds an entity
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        /// <returns>Single response with added entity</returns>
        Task<ISingleResponse<T>> AddAsync(T entity);

        /// <summary>
        /// Counts entities matching <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Filter to be checked</param>
        /// <returns>Number of entities matching filter</returns>
        Task<long> CountAsync(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        /// <returns>Response with result of delete operation</returns>
        Task<IResponse> DeleteAsync(T entity);

        /// <summary>
        /// Checks if entity matching <paramref name="predicate"/> exists
        /// </summary>
        /// <param name="predicate">Filter to be checked</param>
        /// <returns>True if an entity exists matching filter, else False</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets an entity matching <paramref name="predicate"/> with includes
        /// specified in <paramref name="includeString"/>
        /// </summary>
        /// <param name="predicate">Filter to be checked</param>
        /// <param name="includeString">Include properties as string seperated with comma</param>
        /// <returns>Single response with entity matching filter with included properties</returns>
        Task<ISingleResponse<T>> GetAsync(Expression<Func<T, bool>> predicate, string includeString = "");

        /// <summary>
        /// Lists all entities with paging support
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paged response of all entities</returns>
        Task<IPagedResponse<T>> ListAllAsync(int? page = null, int? pageSize = null);

        /// <summary>
        /// Lists entities matching <paramref name="predicate"/> with paging support
        /// </summary>
        /// <param name="predicate">Filter to be checked</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paged response of entities matching filter</returns>
        Task<IPagedResponse<T>> ListAsync(Expression<Func<T, bool>> predicate, int? page = null, int? pageSize = null);

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
        /// <returns>Paged response of entities matching filter</returns>
        Task<IPagedResponse<T>> ListAsync(Expression<Func<T, bool>> predicate = null,
                                          Expression<Func<T, object>> groupBy = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          string includeString = "",
                                          int? page = null,
                                          int? pageSize = null,
                                          bool disableTracking = true);

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
        /// <returns>Paged response of entities matching filter</returns>
        Task<IPagedResponse<T>> ListAsync(Expression<Func<T, bool>> predicate = null,
                                          Expression<Func<T, object>> groupBy = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          List<Expression<Func<T, object>>> includes = null,
                                          int? page = null,
                                          int? pageSize = null,
                                          bool disableTracking = true);

        /// <summary>
        /// Lists entities for Datatables support
        /// </summary>
        /// <param name="dtParameters"></param>
        /// <returns>Entities in Datatables response format</returns>
        Task<DTResult<T>> LoadDatatableAsync(DTParameters dtParameters);

        /// <summary>
        /// Updates an entity at context
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        /// <returns>Response with result of update operation</returns>
        Task<IResponse> UpdateAsync(T entity);
    }
}