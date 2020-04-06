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
    /// Client entity service
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class ClientService : BaseService<Client>, IClientService
    {
        /// <summary>
        /// Client service constructor
        /// </summary>
        /// <param name="unitOfWork">Unit of work instance</param>
        /// <param name="logger">Logger instance</param>
        public ClientService(IUnitOfWork unitOfWork, ILogger<BaseService<Client>> logger)
            : base(unitOfWork, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IResponse> AddToGroupAsync(GroupMember groupMember)
        {
            _logger.LogDebug($"'{nameof(AddToGroupAsync)}' has been invoked");

            var response = new Response();

            try
            {
                var groupMemberRepository = _unitOfWork.GetRepository<GroupMember>();
                if (!await groupMemberRepository.ExistsAsync(gm => gm.GroupId == groupMember.GroupId && gm.ClientId == groupMember.ClientId))
                {
                    await groupMemberRepository.AddAsync(groupMember);
                    await _unitOfWork.SaveAsync();
                }

                response.Message = $"Client '{groupMember.ClientId}' added to Group '{groupMember.GroupId}' successfully";
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(AddToGroupAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public override async Task<DTResult<Client>> LoadDatatableAsync(DTParameters dtParameters)
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

            var result = await _repository.ListAsync(includeString: "Groups.Group, NotificationsSent, NotificationsReceived");

            if (!string.IsNullOrEmpty(searchBy))
            {
                result = result.Where(r => r.Id != null && r.Id.ToUpper().Contains(searchBy.ToUpper()) ||
                                           r.Name != null && r.Name.ToUpper().Contains(searchBy.ToUpper()) ||
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

            return new DTResult<Client>()
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

        /// <inheritdoc/>
        public async Task<IResponse> RemoveFromGroupAsync(GroupMember groupMember)
        {
            _logger.LogDebug($"'{nameof(RemoveFromGroupAsync)}' has been invoked");

            var response = new Response();

            try
            {
                var groupMemberRepository = _unitOfWork.GetRepository<GroupMember>();
                if (await groupMemberRepository.ExistsAsync(gm => gm.GroupId == groupMember.GroupId && gm.ClientId == groupMember.ClientId))
                {
                    groupMemberRepository.Delete(groupMember);
                    await _unitOfWork.SaveAsync();
                }

                response.Message = $"Client '{groupMember.ClientId}' removed from Group '{groupMember.GroupId}' successfully";
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(RemoveFromGroupAsync), _logger);
            }

            return response;
        }
    }
}