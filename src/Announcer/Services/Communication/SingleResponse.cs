using Announcer.Contracts.v1;

namespace Announcer.Services.Communication
{
    /// <summary>
    /// Single entity response for service communications
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class SingleResponse<T> : Response, ISingleResponse<T>
    {
        /// <inheritdoc/>
        public T Model { get; set; }
    }
}