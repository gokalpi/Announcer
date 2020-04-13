using Announcer.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Announcer.Controllers
{
    /// <summary>
    /// Group Notification Api Controller v1
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupNotificationsController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public GroupNotificationsController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext ?? throw new System.ArgumentNullException(nameof(hubContext));
        }

        [HttpPost]
        public async Task SendMessageToGroup(string groupName, string message)
        {
            await _hubContext.Clients.Group(groupName).SendAsync("ReceiveGroupMessage", new
            {
                Group = groupName,
                Message = message
            });
        }
    }
}