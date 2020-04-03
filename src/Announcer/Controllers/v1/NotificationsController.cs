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
    /// Notification Api Controller v1
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequireAdministratorRole")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<NotificationsController> _logger;

        /// <summary>
        /// Notification Api Controller constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="mapper">Automapper instance</param>
        /// <param name="logger"></param>
        public NotificationsController(INotificationService service, IMapper mapper, ILogger<NotificationsController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Creates a Notification.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/Notifications
        ///     {
        ///         "content": "Sample Group Notification 1",
        ///         "sentTime": "2020-03-06T12:50:00.000Z",
        ///         "senderId": "10.126.3.39",
        ///         "groupId": "b5b17e73-3ec4-465e-9405-04f704de3422",
        ///         "recipientId": ""
        ///     }
        /// </remarks>
        /// <param name="notificationDTO">Notification to be created</param>
        /// <param name="version">Version of controller</param>
        /// <returns>A newly created Notification</returns>
        /// <response code="201">Returns the newly created notification</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost]
        [ProducesResponseType(typeof(NotificationDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateNotification([FromBody] SaveNotificationDTO notificationDTO, ApiVersion version)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(CreateNotification));

            if (notificationDTO == null)
                return BadRequest("Notification info is null");

            var response = await _service.AddAsync(_mapper.Map<Notification>(notificationDTO));

            _logger.LogDebug($"Notification with id {response.Model.Id} created.");

            var result = new SingleResponse<NotificationDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<NotificationDTO>(response.Model)
            };

            return CreatedAtAction("GetNotificationById", new { id = result.Model.Id, version = version.ToString() }, result);
        }

        /// <summary>
        /// Deletes a Notification.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/v1/Notifications/35bf23d9-835e-4af9-987a-9cde811b35f5
        /// </remarks>
        /// <param name="id">Notification Id to be deleted</param>
        /// <returns>Deleted Notification</returns>
        /// <response code="200">Returns deleted notification</response>
        /// <response code="400">If the id is null</response>
        /// <response code="404">If the notification is not found</response>
        /// <response code="500">If an exception happens</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteNotification(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(DeleteNotification));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Notification id is null or empty");

            if (!await _service.ExistsAsync(n => n.Id == id))
                return NotFound($"Notification with id {id} not found.");

            var response = await _service.DeleteAsync(id);

            _logger.LogDebug($"Notification with id {id} deleted.");

            return response.ToHttpResponse();
        }

        /// <summary>
        /// Lists all Notifications with paging support.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/Notifications?Page=1&amp;PageSize=4&amp;IsDetailRequired=true
        /// </remarks>
        /// <param name="queryParams">Paging info (page, page size)</param>
        /// <returns>All Notifications with paging support</returns>
        /// <response code="200">Returns all Notifications in specified page</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllNotifications([FromQuery] QueryParams queryParams)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetAllNotifications));

            var includeString = queryParams.IsDetailRequired ? "Sender, Group, Recipient" : "";

            var response = await _service.ListAsync(includeString: includeString, page: queryParams.Page, pageSize: queryParams.PageSize);

            _logger.LogDebug($"Found {response.TotalItems} notifications. Listing page {queryParams.Page} of {response.PageCount}");

            var result = new PagedResponse<NotificationDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                PageNumber = queryParams.Page ?? 0,
                PageSize = queryParams.PageSize ?? 0,
                TotalItems = response.TotalItems,
                Model = _mapper.Map<IEnumerable<NotificationDTO>>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Gets a Notification with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/Notifications/35bf23d9-835e-4af9-987a-9cde811b35f5
        /// </remarks>
        /// <param name="id">Notification id</param>
        /// <returns>Notification with specified id</returns>
        /// <response code="200">Returns Notification with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNotificationById(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetNotificationById));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Notification id is null or empty");

            var response = await _service.GetAsync(g => g.Id == id, "Sender, Group, Recipient");

            _logger.LogDebug($"Found notification with {id}");

            var result = new SingleResponse<NotificationDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                Model = _mapper.Map<NotificationDTO>(response.Model)
            };

            return result.ToHttpResponse();
        }

        /// <summary>
        /// Returns data necessary for Datatables operations
        /// </summary>
        /// <param name="dtParameters">Parameters coming from Datatables</param>
        /// <returns>List of all notifications matching parameters</returns>
        /// <response code="200">Returns all notifications matching parameters</response>
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
                data = _mapper.Map<IEnumerable<NotificationDTO>>(dtResult.Data)
            });
        }

        /// <summary>
        /// Updates Notification with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/v1/Notifications/35bf23d9-835e-4af9-987a-9cde811b35f5
        ///     {
        ///         "content": "Sample Group Notification 1",
        ///         "sentTime": "2020-03-06T12:50:00.000Z",
        ///         "senderId": "10.126.3.39",
        ///         "groupId": "b5b17e73-3ec4-465e-9405-04f704de3422",
        ///         "recipientId": ""
        ///     }
        /// </remarks>
        /// <param name="id">Notification id</param>
        /// <param name="notificationDTO">Notification to be updated</param>
        /// <returns>Notification with specified id</returns>
        /// <response code="204">Returns no content</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateNotification(string id, [FromBody] SaveNotificationDTO notificationDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(UpdateNotification));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Notification id is null or empty");

            var notification = _mapper.Map<Notification>(notificationDTO);
            notification.Id = id;

            var response = await _service.UpdateAsync(notification);

            _logger.LogDebug($"Notification with id {id} updated.");

            return response.ToHttpResponse();
        }
    }
}