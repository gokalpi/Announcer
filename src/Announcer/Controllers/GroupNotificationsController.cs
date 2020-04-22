using Announcer.Contracts;
using Announcer.Dtos.Requests;
using Announcer.Helpers.Extensions;
using Announcer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Announcer.Controllers
{
    /// <summary>
    /// Group Notification Api Controller v1
    /// </summary>
    [ApiVersion("1.0")]
    public class GroupNotificationsController : BaseApiController
    {
        private readonly IGroupNotificationService _service;
        private readonly IMapper _mapper;

        public GroupNotificationsController(IGroupNotificationService service, IMapper mapper,
            IHttpContextAccessor httpContextAccessor, ILogger<GroupNotificationsController> logger)
            : base(httpContextAccessor, logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Sends a group notification.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/GroupNotifications
        ///     {
        ///        "groupName": "Fizik Tedavi 12",
        ///        "message": "{ \"columns\": [ \"Ali Yılmaz\", \"Veli Yıldırım\" ] }"
        ///     }
        /// </remarks>
        /// <param name="notificationDTO">Group notification to be send</param>
        /// <returns></returns>
        /// <response code="200">Returns the newly created group</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SendMessageToGroup(SendGroupNotificationDTO notificationDTO)
        {
            _logger.LogDebug("'{0}' has been invoked", nameof(SendMessageToGroup));

            if (notificationDTO == null)
                return BadRequest("Notification info is null");

            var response = await _service.SendMessageToGroup(_mapper.Map<SendGroupNotification>(notificationDTO));

            _logger.LogDebug($"Notification to {notificationDTO.GroupName} group sent.");

            return response.ToHttpResponse();
        }
    }
}