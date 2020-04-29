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
    /// Notification entity service
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class NotificationService : BaseService<Notification>, INotificationService
    {
        /// <summary>
        /// Notification service constructor
        /// </summary>
        /// <param name="unitOfWork">Unit of work instance</param>
        /// <param name="logger">Logger instance</param>
        public NotificationService(IUnitOfWork unitOfWork, ILogger<BaseService<Notification>> logger)
            : base(unitOfWork, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<ISingleResponse<Notification>> GetByIdAsync(string id)
        {
            _logger.LogDebug($"'{nameof(GetByIdAsync)}' has been invoked");

            var response = new SingleResponse<Notification>();

            try
            {
                response.Model = await _repository.GetAsync(n => n.Id == id, includeDeleted: true);
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(GetByIdAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<IListResponse<Notification>> ListGroupNotificationsByClientAsync(string clientId)
        {
            _logger.LogDebug($"'{nameof(ListGroupNotificationsByClientAsync)}' has been invoked");

            var response = new ListResponse<Notification>();

            try
            {
                if (string.IsNullOrWhiteSpace(clientId))
                    throw new ArgumentNullException(nameof(clientId));

                response.Model = await _repository.ListAsync(predicate: n => n.Group.Clients.Any(gm => gm.ClientId == clientId), includeString: "Sender, Group, Recipient", orderBy: o => o.OrderBy(n => n.Group.Name).ThenBy(n => n.SentTime));
                response.Message = $"Found {response.Model.Count()} group notifications of Client {clientId}";
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(ListGroupNotificationsByClientAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<IListResponse<Notification>> ListNotificationsByClientAsync(string clientId)
        {
            _logger.LogDebug($"'{nameof(ListNotificationsByClientAsync)}' has been invoked");

            var response = new ListResponse<Notification>();

            try
            {
                if (string.IsNullOrWhiteSpace(clientId))
                    throw new ArgumentNullException(nameof(clientId));

                response.Model = await _repository.ListAsync(predicate: n => n.RecipientId == clientId, includeString: "Sender, Group, Recipient", orderBy: o => o.OrderBy(n => n.SentTime));
                response.Message = $"Found {response.Model.Count()} notifications of Client {clientId}";
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(ListNotificationsByClientAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public override async Task<DTResult<Notification>> LoadDatatableAsync(DTParameters dtParameters)
        {
            var searchBy = dtParameters.Search?.Value;
            var isDeleted = dtParameters.Columns[6].Search.Value;

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
                // if we have an empty search then just order the results by Id descending
                orderCriteria = "Id";
                orderAscendingDirection = false;
            }

            var result = await _repository.ListAsync(includeString: "Sender, Group, Recipient");

            if (!string.IsNullOrEmpty(searchBy))
            {
                result = result.Where(n => n.Content != null && n.Content.ToUpper().Contains(searchBy.ToUpper()) ||
                                           n.Sender != null && n.Sender.Name.ToUpper().Contains(searchBy.ToUpper()));
            }

            if (!string.IsNullOrEmpty(isDeleted))
            {
                result = result.Where(r => r.IsDeleted == (isDeleted == "0"));
            }

            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();

            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = await _repository.CountAsync();

            return new DTResult<Notification>()
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