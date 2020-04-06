using Announcer.Contracts;
using Announcer.Helpers.Extensions;
using Announcer.Models;
using Announcer.Services.Communication;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Announcer.Services
{
    /// <summary>
    /// Group entity service
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class GroupService : BaseService<Group>, IGroupService
    {
        /// <summary>
        /// Group service constructor
        /// </summary>
        /// <param name="unitOfWork">Unit of work instance</param>
        /// <param name="logger">Logger instance</param>
        public GroupService(IUnitOfWork unitOfWork, ILogger<BaseService<Group>> logger)
            : base(unitOfWork, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IListResponse<Group>> ListGroupsByClientAsync(string clientId)
        {
            _logger.LogDebug($"'{nameof(ListGroupsByClientAsync)}' has been invoked");

            var response = new ListResponse<Group>();

            try
            {
                if (string.IsNullOrWhiteSpace(clientId))
                    throw new ArgumentNullException(nameof(clientId));

                response.Model = await _repository.ListAsync(predicate: g => g.Clients.Any(gm => gm.ClientId == clientId), includeString: "", orderBy: o => o.OrderBy(g => g.Name));
                response.Message = $"Found {response.Model.Count()} groups of Client {clientId}";
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(ListGroupsByClientAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public override async Task<DTResult<Group>> LoadDatatableAsync(DTParameters dtParameters)
        {
            var searchBy = dtParameters.Search?.Value;
            var isDeleted = dtParameters.Columns[3].Search.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "asc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            var result = await _repository.ListAsync(includeString: "Clients.Client, NotificationsReceived");

            if (!string.IsNullOrEmpty(searchBy))
            {
                result = result.Where(r => r.Name != null && r.Name.ToUpper().Contains(searchBy.ToUpper()) ||
                                           r.Description != null && r.Description.ToUpper().Contains(searchBy.ToUpper()));
            }

            if (!string.IsNullOrEmpty(isDeleted))
            {
                result = result.Where(r => r.IsDeleted == (isDeleted == "0"));
            }

            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();

            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = await _repository.CountAsync();

            return new DTResult<Group>()
            {
                Draw = dtParameters.Draw,
                RecordsTotal = totalResultsCount,
                RecordsFiltered = filteredResultsCount,
                Data = result
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .ToList()
            };
        }
    }
}