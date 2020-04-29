using Announcer.Contracts;
using Announcer.Helpers.Extensions;
using Announcer.Models;
using Announcer.Services.Communication;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Announcer.Services
{
    /// <summary>
    /// Base service
    /// </summary>
    /// <typeparam name="T">Entity used with service</typeparam>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class BaseService<T> : IService<T> where T : class, IEntity
    {
        protected readonly ILogger<BaseService<T>> _logger;
        protected readonly IRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Base service constructor
        /// </summary>
        /// <param name="unitOfWork">Unit of work instance</param>
        /// <param name="logger">Logger instance</param>
        public BaseService(IUnitOfWork unitOfWork, ILogger<BaseService<T>> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _repository = _unitOfWork.GetRepository<T>();
        }

        /// <inheritdoc/>
        public async Task<ISingleResponse<T>> AddAsync(T entity)
        {
            _logger.LogDebug($"'{nameof(AddAsync)}' has been invoked");

            var response = new SingleResponse<T>();

            try
            {
                await _repository.AddAsync(entity);
                await _unitOfWork.SaveAsync();

                response.Model = entity;
                response.Message = $"{typeof(T)} added successfully";
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(AddAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<long> CountAsync(Expression<Func<T, bool>> predicate = null, bool includeDeleted = false)
        {
            _logger.LogDebug($"'{nameof(CountAsync)}' has been invoked");

            return await _repository.CountAsync(predicate, includeDeleted);
        }

        /// <inheritdoc/>
        public async Task<IResponse> DeleteAsync(T entity)
        {
            _logger.LogDebug($"'{nameof(DeleteAsync)}' has been invoked");

            var response = new Response();

            try
            {
                _repository.Delete(entity);
                await _unitOfWork.SaveAsync();

                response.Message = $"{typeof(T)} deleted successfully";
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(DeleteAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = false)
        {
            _logger.LogDebug($"'{nameof(ExistsAsync)}' has been invoked");

            return await _repository.ExistsAsync(predicate, includeDeleted);
        }

        /// <inheritdoc/>
        public async Task<ISingleResponse<T>> GetAsync(Expression<Func<T, bool>> predicate, string includeString = "", bool includeDeleted = false)
        {
            _logger.LogDebug($"'{nameof(GetAsync)}' has been invoked");

            var response = new SingleResponse<T>();

            try
            {
                response.Model = await _repository.GetAsync(predicate, includeString, includeDeleted);
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(GetAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<IPagedResponse<T>> ListAllAsync(int? page = null, int? pageSize = null, bool includeDeleted = false)
        {
            _logger.LogDebug($"'{nameof(ListAllAsync)}' has been invoked");

            var response = new PagedResponse<T>();

            try
            {
                response.TotalItems = await _repository.CountAsync(includeDeleted: includeDeleted);
                response.PageSize = pageSize ?? 0;
                response.CurrentPage = page ?? 0;
                response.Message = $"Found {response.TotalItems} {typeof(T)}. Listing page {response.CurrentPage} of {response.TotalPages}";
                response.Model = await _repository.ListAllAsync(response.CurrentPage, response.PageSize, includeDeleted);
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(ListAllAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<IPagedResponse<T>> ListAsync(Expression<Func<T, bool>> predicate, int? page = null, int? pageSize = null, bool includeDeleted = false)
        {
            _logger.LogDebug($"'{nameof(ListAsync)}' has been invoked");

            var response = new PagedResponse<T>();

            try
            {
                response.TotalItems = await _repository.CountAsync(includeDeleted: includeDeleted);
                response.PageSize = pageSize ?? 0;
                response.CurrentPage = page ?? 0;
                response.Message = $"Found {response.TotalItems} {typeof(T)}. Listing page {response.CurrentPage} of {response.TotalPages}";
                response.Model = await _repository.ListAsync(predicate, response.CurrentPage, response.PageSize, includeDeleted);
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(ListAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<IPagedResponse<T>> ListAsync(Expression<Func<T, bool>> predicate = null,
                                                       Expression<Func<T, object>> groupBy = null,
                                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                       string includeString = "",
                                                       int? page = null,
                                                       int? pageSize = null,
                                                       bool disableTracking = true,
                                                       bool includeDeleted = false)
        {
            _logger.LogDebug($"'{nameof(ListAsync)}' has been invoked");

            var response = new PagedResponse<T>();

            try
            {
                response.TotalItems = await _repository.CountAsync(includeDeleted: includeDeleted);
                response.PageSize = pageSize ?? 0;
                response.CurrentPage = page ?? 0;
                response.Message = $"Found {response.TotalItems} {typeof(T)}. Listing page {response.CurrentPage} of {response.TotalPages}";
                response.Model = await _repository.ListAsync(predicate, groupBy, orderBy, includeString, response.CurrentPage, response.PageSize, disableTracking, includeDeleted);
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(ListAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<IPagedResponse<T>> ListAsync(Expression<Func<T, bool>> predicate = null,
                                                       Expression<Func<T, object>> groupBy = null,
                                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                       List<Expression<Func<T, object>>> includes = null,
                                                       int? page = null,
                                                       int? pageSize = null,
                                                       bool disableTracking = true,
                                                       bool includeDeleted = false)
        {
            _logger.LogDebug($"'{nameof(ListAsync)}' has been invoked");

            var response = new PagedResponse<T>();

            try
            {
                response.TotalItems = await _repository.CountAsync(includeDeleted: includeDeleted);
                response.PageSize = pageSize ?? 0;
                response.CurrentPage = page ?? 0;
                response.Message = $"Found {response.TotalItems} {typeof(T)}. Listing page {response.CurrentPage} of {response.TotalPages}";
                response.Model = await _repository.ListAsync(predicate, groupBy, orderBy, includes, response.CurrentPage, response.PageSize, disableTracking, includeDeleted);
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(ListAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public virtual async Task<DTResult<T>> LoadDatatableAsync(DTParameters dtParameters)
        {
            _logger.LogDebug($"'{nameof(LoadDatatableAsync)}' has been invoked");

            return await Task.FromResult(new DTResult<T>());
        }

        /// <inheritdoc/>
        public async Task<IResponse> UpdateAsync(T entity)
        {
            _logger.LogDebug($"'{nameof(UpdateAsync)}' has been invoked");

            var response = new Response();

            try
            {
                _repository.Update(entity);
                await _unitOfWork.SaveAsync();

                response.Message = $"{typeof(T)} updated successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error on '{0}' invocation: {1}", nameof(UpdateAsync), (ex.InnerException != null) ? ex.InnerException.Message : ex.Message);

                response.IsSuccessful = false;
                response.Message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
            }

            return response;
        }
    }
}