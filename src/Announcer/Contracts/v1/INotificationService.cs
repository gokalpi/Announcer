using Announcer.Models.v1;
using System.Threading.Tasks;

namespace Announcer.Contracts.v1
{
    /// <summary>
    /// Notification service interface
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface INotificationService : IService<Notification>
    {
        /// <summary>
        /// Lists all notifications of client
        /// </summary>
        /// <param name="clientId">Client id</param>
        /// <returns>List response of all notifications of client</returns>
        Task<IListResponse<Notification>> ListNotificationsByClientAsync(string clientId);
    }
}