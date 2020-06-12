using Announcer.Contracts;
using Announcer.Dtos.Requests;
using Announcer.Helpers.Extensions;
using Announcer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class GroupNotificationsController : BaseApiController
    {
        private readonly IGroupNotificationService _groupNotificationService;
        private readonly ISettingService _settingService;

        public GroupNotificationsController(IGroupNotificationService groupNotificationService, ISettingService settingService, IMapper mapper,
            IHttpContextAccessor httpContextAccessor, ILogger<GroupNotificationsController> logger)
            : base(mapper, httpContextAccessor, logger)
        {
            _groupNotificationService = groupNotificationService ?? throw new ArgumentNullException(nameof(groupNotificationService));
            _settingService = settingService ?? throw new ArgumentNullException(nameof(settingService));
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

            var response = await _groupNotificationService.SendMessageToGroup(_mapper.Map<SendGroupNotification>(notificationDTO));

            _logger.LogDebug($"Notification to {notificationDTO.GroupName} group sent.");

            return response.ToHttpResponse();
        }
    }
}