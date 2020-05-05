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
        public async Task<ISingleResponse<GroupMember>> AddToGroupAsync(GroupMember groupMember)
        {
            _logger.LogDebug($"'{nameof(AddToGroupAsync)}' has been invoked");

            var response = new SingleResponse<GroupMember>();

            try
            {
                var groupMemberRepository = _unitOfWork.GetRepository<GroupMember>();
                if (!await groupMemberRepository.ExistsAsync(gm => gm.GroupId == groupMember.GroupId && gm.ClientId == groupMember.ClientId))
                {
                    await groupMemberRepository.AddAsync(groupMember);
                    await _unitOfWork.SaveAsync();

                    response.Model = await groupMemberRepository.GetAsync(gm => gm.GroupId == groupMember.GroupId && gm.ClientId == groupMember.ClientId, "Group, Client");
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
        public async Task<ISingleResponse<Client>> GetByIdAsync(string id)
        {
            _logger.LogDebug($"'{nameof(GetByIdAsync)}' has been invoked");

            var response = new SingleResponse<Client>();

            try
            {
                response.Model = await _repository.GetAsync(c => c.Id == id, includeDeleted: true);
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(GetByIdAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<IListResponse<Client>> ListClientsByGroupAsync(int groupId)
        {
            _logger.LogDebug($"'{nameof(ListClientsByGroupAsync)}' has been invoked");

            var response = new ListResponse<Client>();

            try
            {
                response.Model = await _repository.ListAsync(predicate: c => c.Groups.Any(gm => gm.GroupId == groupId), includeString: "", orderBy: o => o.OrderBy(g => g.Name));
                response.Message = $"Found {response.Model.Count()} clients of Group {groupId}";
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(ListClientsByGroupAsync), _logger);
            }

            return response;
        }

        /// <inheritdoc/>
        public async Task<IListResponse<Client>> ListClientsByTemplateAsync(int templateId)
        {
            _logger.LogDebug($"'{nameof(ListClientsByTemplateAsync)}' has been invoked");

            var response = new ListResponse<Client>();

            try
            {
                response.Model = await _repository.ListAsync(predicate: c => c.TemplateId == templateId, includeString: "Template", orderBy: o => o.OrderBy(g => g.Name));
                response.Message = $"Found {response.Model.Count()} clients of Template {templateId}";
            }
            catch (Exception ex)
            {
                response.SetError(ex, nameof(ListClientsByTemplateAsync), _logger);
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

            var result = await _repository.ListAsync(includeString: "Template, Groups.Group, NotificationsSent, NotificationsReceived", includeDeleted: true);

            if (!string.IsNullOrEmpty(searchBy))
            {
                result = result.Where(c => c.Id != null && c.Id.ToUpper().Contains(searchBy.ToUpper()) ||
                                           c.Name != null && c.Name.ToUpper().Contains(searchBy.ToUpper()) ||
                                           c.Description != null && c.Description.ToUpper().Contains(searchBy.ToUpper()));
            }

            if (!string.IsNullOrEmpty(isDeleted))
            {
                result = result.Where(c => c.IsDeleted == (isDeleted == "0"));
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
        public async Task<ISingleResponse<GroupMember>> RemoveFromGroupAsync(GroupMember groupMember)
        {
            _logger.LogDebug($"'{nameof(RemoveFromGroupAsync)}' has been invoked");

            var response = new SingleResponse<GroupMember>();

            try
            {
                var groupMemberRepository = _unitOfWork.GetRepository<GroupMember>();
                var existingGroupMember = await groupMemberRepository.GetAsync(gm => gm.GroupId == groupMember.GroupId && 
                                                                            gm.ClientId == groupMember.ClientId, "Group, Client");
                if (existingGroupMember != null)
                {
                    groupMemberRepository.Delete(groupMember);
                    await _unitOfWork.SaveAsync();

                    response.Model = existingGroupMember;
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