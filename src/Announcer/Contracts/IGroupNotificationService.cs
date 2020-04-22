using Announcer.Dtos.Requests;
using Announcer.Models;
using System.Threading.Tasks;

namespace Announcer.Contracts
{
    /// <summary>
    /// Group notification service interface
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface IGroupNotificationService
    {
        /// <summary>
        /// Sends notification to specified group
        /// </summary>
        /// <param name="groupNotification">Group notification</param>
        /// <returns>Response with result of group notification sending operation</returns>
        Task<IResponse> SendMessageToGroup(SendGroupNotification groupNotification);
    }
}