using Announcer.Contracts.v1;
using System.Collections.Generic;

namespace Announcer.Services.Communication
{
    /// <summary>
    /// List of entity response for service communications
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class ListResponse<T> : Response, IListResponse<T>
    {
        /// <inheritdoc/>
        public IEnumerable<T> Model { get; set; }
    }
}