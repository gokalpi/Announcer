using Announcer.Contracts.v1;
using Announcer.Dtos.Requests.v1;
using Announcer.Dtos.Responses.v1;
using Announcer.Helpers.Extensions;
using Announcer.Models.v1;
using Announcer.Services.Communication;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcer.Controllers.v1
{
    /// <summary>
    /// Group Api Controller v1
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<GroupsController> _logger;

        /// <summary>
        /// Group Api Controller constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="mapper">Automapper instance</param>
        /// <param name="logger"></param>
        public GroupsController(IGroupService service, IMapper mapper, ILogger<GroupsController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Creates a Group.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/Groups
        ///     {
        ///         "name": "Sample Group",
        ///         "description": "Sample Group Description"
        ///     }
        /// </remarks>
        /// <param name="groupDTO">Group to be created</param>
        /// <param name="version">Version of controller</param>
        /// <returns>A newly created Group</returns>
        /// <response code="201">Returns the newly created group</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost]
        [ProducesResponseType(typeof(GroupDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GroupDTO>> CreateGroup([FromBody] SaveGroupDTO groupDTO, ApiVersion version = default)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(CreateGroup));

            if (groupDTO == null)
                return BadRequest("Group info is null");

            var response = await _service.AddAsync(_mapper.Map<Group>(groupDTO));

            _logger.LogDebug($"Group with id {response.Model.Id} created.");

            var result = new SingleResponse<GroupDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<GroupDTO>(response.Model)
            };

            return CreatedAtAction("GetGroupById", new { id = result.Model.Id, version = version.ToString() }, result);
        }

        /// <summary>
        /// Deletes a Group.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/v1/Groups/35bf23d9-835e-4af9-987a-9cde811b35f5
        /// </remarks>
        /// <param name="id">Group Id to be deleted</param>
        /// <returns>Deleted Group</returns>
        /// <response code="200">Returns deleted group</response>
        /// <response code="400">If the id is null</response>
        /// <response code="404">If the group is not found</response>
        /// <response code="500">If an exception happens</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteGroup(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(DeleteGroup));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Group id is null or empty");

            if (!await _service.ExistsAsync(g => g.Id == id))
                return NotFound($"Group with id {id} not found.");

            var response = await _service.DeleteAsync(id);

            _logger.LogDebug($"Group with id {id} deleted.");

            return response.ToHttpResponse();
        }

        /// <summary>
        /// Lists all Groups with paging support.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/Groups?Page=1&amp;PageSize=4&amp;IsDetailRequired=true
        /// </remarks>
        /// <param name="queryParams">Paging info (page, page size)</param>
        /// <returns>All Groups with paging support</returns>
        /// <response code="200">Returns all Groups in specified page</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllGroups([FromQuery] QueryParams queryParams)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetAllGroups));

            var includeString = queryParams.IsDetailRequired ? "Clients.Client, NotificationsReceived" : "";

            var response = await _service.ListAsync(includeString: includeString, page: queryParams.Page, pageSize: queryParams.PageSize);

            _logger.LogDebug($"Found {response.TotalItems} groups. Listing page {queryParams.Page} of {response.PageCount}");

            var result = new PagedResponse<GroupDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                PageNumber = queryParams.Page ?? 0,
                PageSize = queryParams.PageSize ?? 0,
                TotalItems = response.TotalItems,
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
        ///     GET /api/v1/Groups/35bf23d9-835e-4af9-987a-9cde811b35f5
        /// </remarks>
        /// <param name="id">Group id</param>
        /// <returns>Group with specified id</returns>
        /// <response code="200">Returns Group with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroupById(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetGroupById));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Group id is null or empty");

            var response = await _service.GetAsync(g => g.Id == id, "Clients.Client, NotificationsReceived");

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
        public async Task<IActionResult> LoadTable([FromBody] DTParameters dtParameters)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(LoadTable));

            var dtResult = await _service.LoadDatatableAsync(dtParameters);

            return Ok(new
            {
                draw = dtResult.Draw,
                recordsTotal = dtResult.RecordsTotal,
                recordsFiltered = dtResult.RecordsFiltered,
                data = _mapper.Map<IEnumerable<GroupDTO>>(dtResult.Data)
            });
        }

        /// <summary>
        /// Updates Group with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/v1/Groups/35bf23d9-835e-4af9-987a-9cde811b35f5
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
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGroup(string id, [FromBody] SaveGroupDTO groupDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(UpdateGroup));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Group id is null or empty");

            var group = _mapper.Map<Group>(groupDTO);
            group.Id = id;

            var response = await _service.UpdateAsync(group);

            _logger.LogDebug($"Group with id {id} updated.");

            return response.ToHttpResponse();
        }
    }
}