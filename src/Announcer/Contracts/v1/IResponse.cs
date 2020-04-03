namespace Announcer.Contracts.v1
{
    /// <summary>
    /// Base response interface for service communications
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface IResponse
    {
        /// <summary>
        /// Service operation ended successfully?
        /// </summary>
        bool IsSuccessful { get; set; }

        /// <summary>
        /// Result message for service operations
        /// </summary>
        string Message { get; set; }
    }
}