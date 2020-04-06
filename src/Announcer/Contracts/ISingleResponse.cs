namespace Announcer.Contracts
{
    /// <summary>
    /// Single entity response interface for service communications
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface ISingleResponse<T> : IResponse
    {
        /// <summary>
        /// Single entity result of service operation
        /// </summary>
        T Model { get; set; }
    }
}