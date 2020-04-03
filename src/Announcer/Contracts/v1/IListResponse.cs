using System.Collections.Generic;

namespace Announcer.Contracts.v1
{
    /// <summary>
    /// List of entity response interface for service communications
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface IListResponse<T> : IResponse
    {
        /// <summary>
        /// List of entity result of service operation
        /// </summary>
        IEnumerable<T> Model { get; set; }
    }
}