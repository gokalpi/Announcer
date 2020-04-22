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
    /// Group Api Controller
    /// </summary>
    [ApiVersion("1.0")]
    //[Authorize(Policy = "RequireAdministratorRole")]
    public class GroupsController : BaseApiController
    {
        private readonly IGroupService _service;

        /// <summary>
        /// Group Api Controller constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="mapper">Automapper instance</param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="logger"></param>
        public GroupsController(IGroupService service, IMapper mapper, IHttpContextAccessor httpContextAccessor, ILogger<GroupsController> logger)
            : base(mapper, httpContextAccessor, logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Creates a Group.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Groups
        ///     {
        ///         "name": "Sample Group",
        ///         "description": "Sample Group Description"
        ///     }
        /// </remarks>
        /// <param name="groupDTO">Group to be created</param>
        /// <returns>A newly created Group</returns>
        /// <response code="201">Returns the newly created group</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost]
        [ProducesResponseType(typeof(GroupDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GroupDTO>> CreateGroupAsync([FromBody] SaveGroupDTO groupDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(CreateGroupAsync));

            if (groupDTO == null) return BadRequest("Group info is null");

            // Check if group exists
            var getResult = await _service.GetAsync(g => g.Name == groupDTO.Name && !g.IsDeleted);
            if (!getResult.IsSuccessful)
                return BadRequest(getResult.Message);
            else if (getResult.Model != null)
                return BadRequest($"A group with name {groupDTO.Name} exists");

            // Create a new group
            var addResult = await _service.AddAsync(_mapper.Map<Group>(groupDTO));
            if (!addResult.IsSuccessful)
                return BadRequest(getResult.Message);

            _logger.LogDebug($"Group '{addResult.Model.Name}' with id '{addResult.Model.Id}' created.");

            return CreatedAtRoute("GetGroup", new { id = addResult.Model.Id },
                _mapper.Map<GroupDTO>(addResult.Model));
        }

        /// <summary>
        /// Deletes a Group.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE api/Groups/35bf23d9-835e-4af9-987a-9cde811b35f5
        /// </remarks>
        /// <param name="id">Group Id to be deleted</param>
        /// <returns>Deleted Group</returns>
        /// <response code="200">Returns deleted group</response>
        /// <response code="400">If the id is null</response>
        /// <response code="404">If the group is not found</response>
        /// <response code="500">If an exception happens</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteGroupAsync(int id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(DeleteGroupAsync));

            // Check if group exists
            var getResult = await _service.GetAsync(g => g.Id == id && !g.IsDeleted);
            if (!getResult.IsSuccessful)
                return BadRequest(getResult.Message);
            else if (getResult.Model == null)
                return NotFound($"Group with id {id} not found.");

            // Delete group
            var deleteResult = await _service.DeleteAsync(getResult.Model);

            if (deleteResult.IsSuccessful)
                _logger.LogDebug($"Group with id {id} deleted.");

            return deleteResult.ToHttpResponse();
        }

        /// <summary>
        /// Lists all Groups with paging support.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Groups?Page=1&amp;PageSize=4&amp;IsDetailRequired=true
        /// </remarks>
        /// <param name="queryParams">Paging info (page, page size)</param>
        /// <returns>All Groups with paging support</returns>
        /// <response code="200">Returns all Groups in specified page</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllGroupsAsync([FromQuery] QueryParams queryParams)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetAllGroupsAsync));

            var includeString = queryParams.IsDetailRequired ?
                "Clients.Client, NotificationsReceived" : "";

            var response = await _service.ListAsync(includeString: includeString,
                page: queryParams.Page, pageSize: queryParams.PageSize);

            _logger.LogDebug($"Found {response.TotalItems} groups. Listing page {queryParams.Page} of {response.TotalPages}");

            var result = new PagedResponse<GroupDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                TotalItems = response.TotalItems,
                PageSize = queryParams.PageSize ?? 0,
                CurrentPage = queryParams.Page ?? 0,
                Model = _mapper.Map<IEnumerable<GroupDTO>>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Gets groups of a Client with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Groups/35bf23d9-835e-4af9-987a-9cde811b35f5/Clients
        /// </remarks>
        /// <param name="id">Client id</param>
        /// <returns>Groups of Client with specified id</returns>
        /// <response code="200">Returns groups of Client with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id}/Clients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientsByGroupAsync(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetClientsByGroupAsync));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Group id is null or empty");

            var response = await _service.ListGroupsByClientAsync(id);

            var result = new ListResponse<GroupDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<IEnumerable<GroupDTO>>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Gets a Group with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Groups/35bf23d9-835e-4af9-987a-9cde811b35f5
        /// </remarks>
        /// <param name="id">Group id</param>
        /// <returns>Group with specified id</returns>
        /// <response code="200">Returns Group with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id:int}", Name = "GetGroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroupByIdAsync(int id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetGroupByIdAsync));

            var response = await _service.GetAsync(g => g.Id == id,
                "Clients.Client, NotificationsReceived");

            _logger.LogDebug($"Found group with {id}");

            var result = new SingleResponse<GroupDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<GroupDTO>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Returns data necessary for Datatables operations
        /// </summary>
        /// <param name="dtParameters">Parameters coming from Datatables</param>
        /// <returns>List of all groups matching parameters</returns>
        /// <response code="200">Returns all groups matching parameters</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost("LoadTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoadTableAsync([FromBody] DTParameters dtParameters)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(LoadTableAsync));

            try
            {
                var dtResult = await _service.LoadDatatableAsync(dtParameters);

                return Ok(new
                {
                    draw = dtResult.Draw,
                    recordsTotal = dtResult.RecordsTotal,
                    recordsFiltered = dtResult.RecordsFiltered,
                    data = _mapper.Map<IEnumerable<GroupDTO>>(dtResult.Data)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates Group with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/Groups/35bf23d9-835e-4af9-987a-9cde811b35f5
        ///     {
        ///         "groupName": "Group 2",
        ///         "description": "Group 2"
        ///     }
        /// </remarks>
        /// <param name="id">Group id</param>
        /// <param name="groupDTO">Group to be updated</param>
        /// <returns>Group with specified id</returns>
        /// <response code="204">Returns no content</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGroupAsync(int id, [FromBody] SaveGroupDTO groupDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(UpdateGroupAsync));

            // Check if group exists
            var getResult = await _service.GetAsync(g => g.Id == id && !g.IsDeleted);
            if (!getResult.IsSuccessful)
                return BadRequest(getResult.Message);
            else if (getResult.Model == null)
                return NotFound($"Group with id {id} not found.");

            // Update group
            var oldGroup = getResult.Model; 
            _mapper.Map(groupDTO, oldGroup);

            var response = await _service.UpdateAsync(oldGroup);

            _logger.LogDebug($"Group with id {id} updated.");

            return response.ToHttpResponse();
        }
    }
}