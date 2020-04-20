using Announcer.Models;
using System.Threading.Tasks;

namespace Announcer.Contracts
{
    /// <summary>
    /// Client service interface
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface IClientService : IService<Client>
    {
        /// <summary>
        /// Adds a client to a group
        /// </summary>
        /// <param name="groupMember">Group membership of client</param>
        /// <returns>Response with result of group add operation</returns>
        Task<IResponse> AddToGroupAsync(GroupMember groupMember);

        /// <summary>
        /// Lists all clients of group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <returns>List response of all clients of group</returns>
        Task<IListResponse<Client>> ListClientsByGroupAsync(int groupId);

        /// <summary>
        /// Removes a client from a group
        /// </summary>
        /// <param name="groupMember">Group membership of client</param>
        /// <returns>Response with result of group remove operation</returns>
        Task<IResponse> RemoveFromGroupAsync(GroupMember groupMember);
    }
}