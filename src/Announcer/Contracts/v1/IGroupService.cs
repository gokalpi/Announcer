using Announcer.Models.v1;
using System.Threading.Tasks;

namespace Announcer.Contracts.v1
{
    /// <summary>
    /// Group service interface
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface IGroupService : IService<Group>
    {
        /// <summary>
        /// Lists all groups of client
        /// </summary>
        /// <param name="clientId">Client id</param>
        /// <returns>List response of all groups of client</returns>
        Task<IListResponse<Group>> ListGroupsByClientAsync(string clientId);
    }
}