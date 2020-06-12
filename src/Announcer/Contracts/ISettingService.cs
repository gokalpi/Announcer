using Announcer.Models;
using System.Threading.Tasks;

namespace Announcer.Contracts
{
    /// <summary>
    /// Setting service interface
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface ISettingService : IService<Setting>
    {
        /// <summary>
        /// Gets a setting with specified <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id of the setting</param>
        /// <returns>Setting with specified id</returns>
        Task<ISingleResponse<Setting>> GetByIdAsync(int id);

        /// <summary>
        /// Gets a setting with specified <paramref name="key"/>
        /// </summary>
        /// <param name="key">Key of the setting</param>
        /// <returns>Setting with specified key</returns>
        Task<ISingleResponse<Setting>> GetByKeyAsync(string key);
    }
}