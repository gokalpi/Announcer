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
    /// Notification Api Controller v1
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize(Policy = "RequireAdministratorRole")]
    public class NotificationsController : BaseApiController
    {
        private readonly INotificationService _service;

        /// <summary>
        /// Notification Api Controller constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="mapper">Automapper instance</param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="logger"></param>
        public NotificationsController(INotificationService service, IMapper mapper, IHttpContextAccessor httpContextAccessor, ILogger<NotificationsController> logger)
            : base(mapper, httpContextAccessor, logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Creates a Notification.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Notifications
        ///     {
        ///         "content": "Sample Group Notification 1",
        ///         "sentTime": "2020-03-06T12:50:00.000Z",
        ///         "senderId": "10.126.3.39",
        ///         "groupId": "b5b17e73-3ec4-465e-9405-04f704de3422",
        ///         "recipientId": ""
        ///     }
        /// </remarks>
        /// <param name="notificationDTO">Notification to be created</param>
        /// <returns>A newly created Notification</returns>
        /// <response code="201">Returns the newly created notification</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpPost]
        [ProducesResponseType(typeof(NotificationDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateNotification([FromBody] SaveNotificationDTO notificationDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(CreateNotification));

            if (notificationDTO == null) return BadRequest("Notification info is null");

            // Create a new notification
            var addResult = await _service.AddAsync(_mapper.Map<Notification>(notificationDTO));
            if (!addResult.IsSuccessful)
                return BadRequest(addResult.Message);

            _logger.LogDebug($"Notification with id {addResult.Model.Id} created.");

            return CreatedAtRoute("GetNotification", new { id = addResult.Model.Id },
                _mapper.Map<NotificationDTO>(addResult.Model));
        }

        /// <summary>
        /// Deletes a Notification.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Notifications/35bf23d9-835e-4af9-987a-9cde811b35f5
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

            // Check if notification exists
            var getResult = await _service.GetByIdAsync(id);
            if (!getResult.IsSuccessful)
                return BadRequest(getResult.Message);
            else if (getResult.Model == null)
                return NotFound($"Notification with id {id} not found.");

            var response = await _service.DeleteAsync(getResult.Model);

            _logger.LogDebug($"Notification with id {id} deleted.");

            return response.ToHttpResponse();
        }

        /// <summary>
        /// Lists all Notifications with paging support.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Notifications?Page=1&amp;PageSize=4&amp;IsDetailRequired=true
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

            _logger.LogDebug($"Found {response.TotalItems} notifications. Listing page {queryParams.Page} of {response.TotalPages}");

            var result = new PagedResponse<NotificationDTO>()
            {
                IsSuccessful = response.IsSuccessful,
                Message = response.Message,
                TotalItems = response.TotalItems,
                PageSize = queryParams.PageSize ?? 0,
                CurrentPage = queryParams.Page ?? 0,
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
        ///     GET /api/Notifications/35bf23d9-835e-4af9-987a-9cde811b35f5
        /// </remarks>
        /// <param name="id">Notification id</param>
        /// <returns>Notification with specified id</returns>
        /// <response code="200">Returns Notification with specified id</response>
        /// <response code="400">If the id is null</response>
        /// <response code="500">If an exception happens</response>
        [HttpGet("{id}", Name = "GetNotification")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetNotificationById(string id)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(GetNotificationById));

            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Notification id is null or empty");

            var response = await _service.GetAsync(g => g.Id == id, "Sender, Group, Recipient", true);

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

            try
            {
                var dtResult = await _service.LoadDatatableAsync(dtParameters);

                return Ok(new
                {
                    draw = dtResult.Draw,
                    recordsTotal = dtResult.RecordsTotal,
                    recordsFiltered = dtResult.RecordsFiltered,
                    data = _mapper.Map<IEnumerable<NotificationDTO>>(dtResult.Data)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates Notification with specified id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Notifications/35bf23d9-835e-4af9-987a-9cde811b35f5
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