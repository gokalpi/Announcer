using Announcer.Models;
using System.Threading.Tasks;

namespace Announcer.Contracts
{
    /// <summary>
    /// Notification service interface
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface INotificationService : IService<Notification>
    {
        /// <summary>
        /// Gets a notification with specified <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id of the notification</param>
        /// <returns>Notification with specified id</returns>
        Task<ISingleResponse<Notification>> GetByIdAsync(string id);

        /// <summary>
        /// Lists all group notifications of client
        /// </summary>
        /// <param name="clientId">Client id</param>
        /// <returns>List response of all group notifications of client</returns>
        Task<IListResponse<Notification>> ListGroupNotificationsByClientAsync(string clientId);

        /// <summary>
        /// Lists all notifications of client
        /// </summary>
        /// <param name="clientId">Client id</param>
        /// <returns>List response of all notifications of client</returns>
        Task<IListResponse<Notification>> ListNotificationsByClientAsync(string clientId);
    }
}