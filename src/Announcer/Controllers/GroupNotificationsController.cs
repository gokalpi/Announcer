using Announcer.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Announcer.Controllers
{
    /// <summary>
    /// Group Notification Api Controller v1
    /// </summary>
    [ApiVersion("1.0")]
    public class GroupNotificationsController : BaseApiController
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public GroupNotificationsController(IHubContext<NotificationHub> hubContext, IHttpContextAccessor httpContextAccessor, ILogger logger) : base(httpContextAccessor, logger)
        {
            _hubContext = hubContext ?? throw new System.ArgumentNullException(nameof(hubContext));
        }

        [HttpPost]
        public async Task<ActionResult> SendMessageToGroup(string groupName, string message)
        {
            try
            {
                await _hubContext.Clients.Group(groupName).SendAsync("ReceiveGroupMessage", new
                {
                    Group = groupName,
                    Message = message
                });

                _logger.LogInformation($"Message '{message}' sent to group '{groupName}' from '{clientIpAddress}'");

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error occured in {nameof(SendMessageToGroup)}");
                throw ex;
            }
        }
    }
}