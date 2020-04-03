using Announcer.Contracts.v1;
using Announcer.Dtos.Requests.v1;
using Announcer.Dtos.Responses.v1;
using Announcer.Helpers.Extensions;
using Announcer.Models.v1;
using Announcer.Services.Communication;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcer.Controllers.v1
{
    /// <summary>
    /// Client Api Controller v1
    /// </summary>
    [Authorize(Policy = "RequireAdministratorRole")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IGroupService _groupService;
        private readonly ILogger<ClientsController> _logger;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        /// <summary>
        /// Client Api Controller constructor
        /// </summary>
        /// <param name="clientService"></param>
        /// <param name="groupService"></param>
        /// <param name="notificationService"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public ClientsController(IClientService clientService, IGroupService groupService, INotificationService notificationService, IMapper mapper, ILogger<ClientsController> logger)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Adds a Client to a Group.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/Clients/Group
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
        public async Task<IActionResult> AddToGroup([FromBody] SaveGroupMemberDTO groupMemberDTO)
        {
            _logger.LogDebug($"'{nameof(AddToGroup)}' has been invoked");

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
        ///     POST /api/v1/Clients
        ///     {
        ///         "id": "10.1.1.1",
        ///         "name": "Sample Client",
        ///         "description": "Sample Client Description"
        ///     }
        /// </remarks>
        /// <param name="clientDTO">Client to be created</param>
        /// <param name="version">Version of controller</param>
        /// <returns>A newly created Client</returns>
        /// <response code="201">Returns the newly created client</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateClient([FromBody] SaveClientDTO clientDTO, ApiVersion version = default)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(CreateClient));

            if (clientDTO == null)
                return BadRequest("Client info is null");

            var response = await _clientService.AddAsync(_mapper.Map<Client>(clientDTO));

            _logger.LogDebug($"Client with id {response.Model.Id} created.");

            var result = new SingleResponse<ClientDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<ClientDTO>(response.Model)
            };

            return CreatedAtAction("GetClientById", new { id = result.Model.Id, version = version.ToString() }, result);
        }

        /// <summary>
        /// Deletes a Client.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/v1/Clients/35bf23d9-835e-4af9-987a-9cde811b35f5
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
        public async Task<IActionResult> DeleteClient(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(DeleteClient));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Client id is null or empty");

            if (!await _clientService.ExistsAsync(c => c.Id == id))
                return NotFound($"Client with id {id} not found.");

            var response = await _clientService.DeleteAsync(id);

            _logger.LogDebug($"Client with id {id} deleted.");

            return response.ToHttpResponse();
        }

        /// <summary>
        /// Lists all Clients with paging support.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/Clients?Page=3&amp;PageSize=3&amp;IsDetailRequired=true
        /// </remarks>
        /// <param name="queryParams">Paging info (page, page size)</param>
        /// <returns>All Clients with paging support</returns>
        /// <response code="200">Returns all Clients in specified page</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllClients([FromQuery] QueryParams queryParams)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetAllClients));

            var includeString = queryParams.IsDetailRequired ? "Groups.Group, NotificationsSent, NotificationsReceived" : "";

            var response = await _clientService.ListAsync(includeString: includeString, page: queryParams.Page, pageSize: queryParams.PageSize);

            _logger.LogDebug($"Found {response.TotalItems} clients. Listing page {queryParams.Page} of {response.PageCount}");

            var result = new PagedResponse<ClientDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                PageNumber = queryParams.Page ?? 0,
                PageSize = queryParams.PageSize ?? 0,
                TotalItems = response.TotalItems,
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
        ///     GET /api/v1/Clients/35bf23d9-835e-4af9-987a-9cde811b35f5
        /// </remarks>
        /// <param name="id">Client id</param>
        /// <returns>Client with specified id</returns>
        /// <response code="200">Returns Client with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientById(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetClientById));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Client id is null or empty");

            var response = await _clientService.GetAsync(g => g.Id == id, "Groups.Group, NotificationsSent, NotificationsReceived");

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
        ///     GET /api/v1/Clients/35bf23d9-835e-4af9-987a-9cde811b35f5/Groups
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
        public async Task<IActionResult> GetGroupsByClient(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetGroupsByClient));

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
        ///     GET /api/v1/Clients/35bf23d9-835e-4af9-987a-9cde811b35f5/Notifications
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
        public async Task<IActionResult> GetNotificationsByClient(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetNotificationsByClient));

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
        /// Returns data necessary for Datatables operations
        /// </summary>
        /// <param name="dtParameters">Parameters coming from Datatables</param>
        /// <returns>List of all clients matching parameters</returns>
        /// <response code="200">Returns all clients matching parameters</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost("LoadTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoadTable([FromBody] DTParameters dtParameters)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(LoadTable));

            var dtResult = await _clientService.LoadDatatableAsync(dtParameters);

            return Ok(new
            {
                draw = dtResult.Draw,
                recordsTotal = dtResult.RecordsTotal,
                recordsFiltered = dtResult.RecordsFiltered,
                data = _mapper.Map<IEnumerable<ClientDTO>>(dtResult.Data)
            });
        }

        /// <summary>
        /// Removes a Client from a Group.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/v1/Clients/10.1.1.1/Groups/35bf23d9-835e-4af9-987a-9cde811b35f5
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
        public async Task<IActionResult> RemoveFromGroup(string id, string groupId)
        {
            _logger.LogDebug($"'{nameof(RemoveFromGroup)}' has been invoked");

            if (string.IsNullOrEmpty(id))
                return BadRequest("Client info is null");

            if (string.IsNullOrEmpty(groupId))
                return BadRequest("Group info is null");

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
        ///     PUT /api/v1/Clients/35bf23d9-835e-4af9-987a-9cde811b35f5
        ///     {
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
        public async Task<IActionResult> UpdateClient(string id, [FromBody] SaveClientDTO clientDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(UpdateClient));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Client id is null or empty");

            var response = await _clientService.UpdateAsync(_mapper.Map<Client>(clientDTO));

            _logger.LogDebug($"Client with id {id} updated.");

            return response.ToHttpResponse();
        }
    }
}