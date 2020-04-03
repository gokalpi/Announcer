using Announcer.Contracts.v1;

namespace Announcer.Services.Communication
{
    /// <summary>
    /// Base response for service communications
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class Response : IResponse
    {
        /// <inheritdoc/>
        public bool IsSuccessful { get; set; } = true;

        /// <inheritdoc/>
        public string Message { get; set; }
    }
}