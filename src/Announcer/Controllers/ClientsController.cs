using Announcer.Contracts;
using Announcer.Dtos.Requests;
using Announcer.Dtos.Responses;
using Announcer.Helpers.Extensions;
using Announcer.Models;
using Announcer.Services.Communication;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcer.Controllers
{
    /// <summary>
    /// Client Api Controller
    /// </summary>
    [ApiVersion("1.0")]
    //[Authorize(Policy = "RequireAdministratorRole")]
    public class ClientsController : BaseApiController
    {
        private readonly IClientService _clientService;
        private readonly IGroupService _groupService;
        private readonly INotificationService _notificationService;

        /// <summary>
        /// Client Api Controller constructor
        /// </summary>
        /// <param name="clientService"></param>
        /// <param name="groupService"></param>
        /// <param name="notificationService"></param>
        /// <param name="mapper"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="logger"></param>
        public ClientsController(IClientService clientService, IGroupService groupService, INotificationService notificationService,
            IMapper mapper, IHttpContextAccessor httpContextAccessor, ILogger<ClientsController> logger)
            : base(mapper, httpContextAccessor, logger)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        /// <summary>
        /// Adds a Client to a Group.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Clients/10.1.1.1/Group
        ///     {
        ///         "groupId": "35bf23d9-835e-4af9-987a-9cde811b35f5",
        ///         "clientId": "10.1.1.1"
        ///     }
        /// </remarks>
        /// <param name="groupMemberDTO">GroupMember to be created</param>
        /// <response code="200">Status of operation</response>
        /// <response code="400">If the group member is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost("Group")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddToGroupAsync([FromBody] SaveGroupMemberDTO groupMemberDTO)
        {
            _logger.LogDebug($"'{nameof(AddToGroupAsync)}' has been invoked");

            if (groupMemberDTO == null)
                return BadRequest("Group Member info is null");

            var response = await _clientService.AddToGroupAsync(_mapper.Map<GroupMember>(groupMemberDTO));

            _logger.LogDebug($"Client {groupMemberDTO.ClientId} added to group {groupMemberDTO.GroupId}.");

            return response.ToHttpResponse();
        }

        /// <summary>
        /// Creates a Client.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Clients
        ///     {
        ///         "id": "10.1.1.1",
        ///         "name": "Sample Client",
        ///         "description": "Sample Client Description",
        ///         "templateId": null
        ///     }
        /// </remarks>
        /// <param name="clientDTO">Client to be created</param>
        /// <returns>A newly created Client</returns>
        /// <response code="201">Returns the newly created client</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost]
        [ProducesResponseType(typeof(ClientDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClientDTO>> CreateClientAsync([FromBody] SaveClientDTO clientDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(CreateClientAsync));

            if (clientDTO == null) return BadRequest("Client info is null");

            // Check if client exists
            var getResult = await _clientService.GetAsync(c => c.Id == clientDTO.Id && !c.IsDeleted);
            if (!getResult.IsSuccessful)
                return BadRequest(getResult.Message);
            else if (getResult.Model != null)
                return BadRequest($"A client with id {clientDTO.Id} exists");

            // Create a new client
            var addResult = await _clientService.AddAsync(_mapper.Map<Client>(clientDTO));
            if (!addResult.IsSuccessful)
                return BadRequest(getResult.Message);

            _logger.LogDebug($"Client with id {addResult.Model.Id} created.");

            return CreatedAtRoute("GetClient", new { id = addResult.Model.Id },
                _mapper.Map<ClientDTO>(addResult.Model));
        }

        /// <summary>
        /// Deletes a Client.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE api/Clients/10.1.1.1
        /// </remarks>
        /// <param name="id">Client Id to be deleted</param>
        /// <returns>Deleted Client</returns>
        /// <response code="200">Returns result of operation</response>
        /// <response code="400">If the id is null</response>
        /// <response code="404">If the client is not found</response>
        /// <response code="500">If an exception happens</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteClientAsync(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(DeleteClientAsync));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Client id is null or empty");

            // Check if client exists
            var getResult = await _clientService.GetAsync(c => c.Id == id && !c.IsDeleted);
            if (!getResult.IsSuccessful)
                return BadRequest(getResult.Message);
            else if (getResult.Model == null)
                return NotFound($"Client with id {id} not found.");

            // Delete client
            var deleteResult = await _clientService.DeleteAsync(id);

            if (deleteResult.IsSuccessful)
                _logger.LogDebug($"Client with id {id} deleted.");

            return deleteResult.ToHttpResponse();
        }

        /// <summary>
        /// Lists all Clients with paging support.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Clients?Page=3&amp;PageSize=3&amp;IsDetailRequired=true
        /// </remarks>
        /// <param name="queryParams">Paging info (page, page size)</param>
        /// <returns>All Clients with paging support</returns>
        /// <response code="200">Returns all Clients in specified page</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllClientsAsync([FromQuery] QueryParams queryParams)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetAllClientsAsync));

            var includeString = queryParams.IsDetailRequired ?
                "Template, Groups.Group, NotificationsSent, NotificationsReceived" : "";

            var response = await _clientService.ListAsync(includeString: includeString,
                page: queryParams.Page, pageSize: queryParams.PageSize);

            _logger.LogDebug($"Found {response.TotalItems} clients. Listing page {queryParams.Page} of {response.TotalPages}");

            var result = new PagedResponse<ClientDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                TotalItems = response.TotalItems,
                PageSize = queryParams.PageSize ?? 0,
                CurrentPage = queryParams.Page ?? 0,
                Model = _mapper.Map<IEnumerable<ClientDTO>>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Gets a Client with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Clients/10.1.1.1
        /// </remarks>
        /// <param name="id">Client id</param>
        /// <returns>Client with specified id</returns>
        /// <response code="200">Returns Client with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id}", Name = "GetClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientByIdAsync(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetClientByIdAsync));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Client id is null or empty");

            var response = await _clientService.GetAsync(g => g.Id == id,
                "Template, Groups.Group, NotificationsSent, NotificationsReceived");

            _logger.LogDebug($"Found client with {id}");

            var result = new SingleResponse<ClientDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<ClientDTO>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Gets groups of a Client with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Clients/10.1.1.1/Groups
        /// </remarks>
        /// <param name="id">Client id</param>
        /// <returns>Groups of Client with specified id</returns>
        /// <response code="200">Returns groups of Client with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id}/Groups")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroupsByClientAsync(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetGroupsByClientAsync));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Client id is null or empty");

            var response = await _groupService.ListGroupsByClientAsync(id);

            var result = new ListResponse<GroupDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<IEnumerable<GroupDTO>>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Gets notifications of a Client with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Clients/10.1.1.1/Notifications
        /// </remarks>
        /// <param name="id">Client id</param>
        /// <returns>Notifications of Client with specified id</returns>
        /// <response code="200">Returns notifications of Client with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id}/Notifications")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNotificationsByClientAsync(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetNotificationsByClientAsync));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Client id is null or empty");

            var response = await _notificationService.ListNotificationsByClientAsync(id);

            _logger.LogInformation($"Found notifications of client with id {id}.");

            var result = new ListResponse<NotificationDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<IEnumerable<NotificationDTO>>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Gets all notifications of a Client's subscribed groups with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Clients/10.1.1.1/GroupNotifications
        /// </remarks>
        /// <param name="id">Client id</param>
        /// <returns>Group notifications of Client with specified id</returns>
        /// <response code="200">Returns notifications of Client with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id}/GroupNotifications")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroupNotificationsByClientAsync(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetGroupNotificationsByClientAsync));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Client id is null or empty");

            var response = await _notificationService.ListGroupNotificationsByClientAsync(id);

            _logger.LogInformation($"Found group notifications of client with id {id}.");

            var result = new ListResponse<NotificationDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<IEnumerable<NotificationDTO>>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Returns data necessary for Datatables operations
        /// </summary>
        /// <param name="dtParameters">Parameters coming from Datatables</param>
        /// <returns>List of all clients matching parameters</returns>
        /// <response code="200">Returns all clients matching parameters</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost("LoadTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoadTableAsync([FromBody] DTParameters dtParameters)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(LoadTableAsync));

            try
            {
                var dtResult = await _clientService.LoadDatatableAsync(dtParameters);

                return Ok(new
                {
                    draw = dtResult.Draw,
                    recordsTotal = dtResult.RecordsTotal,
                    recordsFiltered = dtResult.RecordsFiltered,
                    data = _mapper.Map<IEnumerable<ClientDTO>>(dtResult.Data)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Removes a Client from a Group.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE api/Clients/10.1.1.1/Groups/35bf23d9-835e-4af9-987a-9cde811b35f5
        /// </remarks>
        /// <param name="id">Client Id to be deleted</param>
        /// <param name="groupId"></param>
        /// <returns>Deleted Client</returns>
        /// <response code="200">Returns deleted client</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpDelete("{id}/Groups/{groupId}")]
        [ProducesResponseType(typeof(ClientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveFromGroupAsync(string id, int groupId)
        {
            _logger.LogDebug($"'{nameof(RemoveFromGroupAsync)}' has been invoked");

            if (string.IsNullOrEmpty(id))
                return BadRequest("Client info is null");

            var response = await _clientService.RemoveFromGroupAsync(new GroupMember(groupId, id));

            _logger.LogDebug($"Client '{id}' removed from group '{groupId}'.");

            return response.ToHttpResponse();
        }

        /// <summary>
        /// Updates Client with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/Clients/10.1.1.1
        ///     {
        ///         "id": "10.1.1.1",
        ///         "clientName": "Client 2",
        ///         "description": "Client 2",
        ///         "templateId": "35bf23d9-835e-4af9-987a-9cde811b35f5"
        ///     }
        /// </remarks>
        /// <param name="id">Client id</param>
        /// <param name="clientDTO">Client to be updated</param>
        /// <returns>Client with specified id</returns>
        /// <response code="200">Returns result of operation</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateClientAsync(string id, [FromBody] SaveClientDTO clientDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(UpdateClientAsync));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Client id is null or empty");

            // Check if client exists
            var getResult = await _clientService.GetAsync(c => c.Id == id && !c.IsDeleted);
            if (!getResult.IsSuccessful)
                return BadRequest(getResult.Message);
            else if (getResult.Model == null)
                return NotFound($"Group with id {id} not found.");

            // Update client
            var oldClient = getResult.Model;
            _mapper.Map(clientDTO, oldClient);

            var response = await _clientService.UpdateAsync(oldClient);

            _logger.LogDebug($"Client with id {id} updated.");

            return response.ToHttpResponse();
        }
    }
}