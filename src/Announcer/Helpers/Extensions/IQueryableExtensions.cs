using Announcer.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Announcer.Helpers.Extensions
{
    /// <summary>
    /// Extension functions for IQueryable
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Apply criteria to specified IQueryable (Filtering, Grouping, Ordering, Include with string)
        /// </summary>
        /// <typeparam name="T">Entity type used with IQueryable</typeparam>
        /// <param name="query">IQueryable used</param>
        /// <param name="predicate">Filtering criteria</param>
        /// <param name="groupBy">Grouping criteria</param>
        /// <param name="orderBy">Ordering criteria</param>
        /// <param name="includeString">Include properties as string</param>
        /// <param name="disableTracking">Query tracking switch</param>
        /// <returns>All entities matching criteria</returns>
        public static IQueryable<T> ApplyCriteria<T>(this IQueryable<T> query,
                                                     Expression<Func<T, bool>> predicate = null,
                                                     Expression<Func<T, object>> groupBy = null,
                                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                     string includeString = "",
                                                     bool disableTracking = true) where T : class, IEntity
        {
            if (disableTracking)
                query = query.AsNoTracking();

            foreach (var includeProperty in includeString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (groupBy != null)
                query = query.GroupBy(groupBy).SelectMany(x => x);

            return query;
        }

        /// <summary>
        /// Apply criteria to specified IQueryable (Filtering, Grouping, Ordering, Include with string)
        /// </summary>
        /// <typeparam name="T">Entity type used with IQueryable</typeparam>
        /// <param name="query">IQueryable used</param>
        /// <param name="predicate">Filtering criteria</param>
        /// <param name="groupBy">Grouping criteria</param>
        /// <param name="orderBy">Ordering criteria</param>
        /// <param name="includes">Include properties as an expression</param>
        /// <param name="disableTracking">Query tracking switch</param>
        /// <returns>All entities matching criteria</returns>
        public static IQueryable<T> ApplyCriteria<T>(this IQueryable<T> query,
                                                     Expression<Func<T, bool>> predicate = null,
                                                     Expression<Func<T, object>> groupBy = null,
                                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                     List<Expression<Func<T, object>>> includes = null,
                                                     bool disableTracking = true) where T : class, IEntity
        {
            if (disableTracking)
                query = query.AsNoTracking();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (groupBy != null)
                query = query.GroupBy(groupBy).SelectMany(x => x);

            return query;
        }

        /// <summary>
        /// Paging support for IQueryable
        /// </summary>
        /// <typeparam name="T">Entity type used with IQueryable</typeparam>
        /// <param name="query">IQueryable used</param>
        /// <param name="page">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>All entities in specified page</returns>
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, int? page = null, int? pageSize = null) where T : class, IEntity
        {
            var pageValue = page.HasValue && page.Value > 0 ? page.Value : 0;
            var pageSizeValue = pageSize.HasValue && pageSize.Value > 0 ? pageSize.Value : 0;

            if (pageValue > 0 && pageSizeValue > 0)
            {
                query = query.Skip((pageValue - 1) * pageSizeValue)
                             .Take(pageSizeValue);
            }

            return query;
        }
    }
}