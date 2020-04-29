using Announcer.Models;
using System.Threading.Tasks;

namespace Announcer.Contracts
{
    /// <summary>
    /// Template service interface
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface ITemplateService : IService<Template>
    {
        /// <summary>
        /// Gets a template with specified <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id of the template</param>
        /// <returns>Template with specified id</returns>
        Task<ISingleResponse<Template>> GetByIdAsync(int id);
    }
}