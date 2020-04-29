using Announcer.Models;
using System.Threading.Tasks;

namespace Announcer.Contracts
{
    /// <summary>
    /// Group service interface
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface IGroupService : IService<Group>
    {
        /// <summary>
        /// Gets a group with specified <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id of the group</param>
        /// <returns>Group with specified id</returns>
        Task<ISingleResponse<Group>> GetByIdAsync(int id);

        /// <summary>
        /// Lists all groups of client
        /// </summary>
        /// <param name="clientId">Client id</param>
        /// <returns>List response of all groups of client</returns>
        Task<IListResponse<Group>> ListGroupsByClientAsync(string clientId);
    }
}