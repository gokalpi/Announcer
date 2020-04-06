namespace Announcer.Contracts
{
    /// <summary>
    /// Paged list of entity response interface for service communications
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface IPagedResponse<T> : IListResponse<T>
    {
        /// <summary>
        /// Total items
        /// </summary>
        long TotalItems { get; set; }

        /// <summary>
        /// Number of pages
        /// </summary>
        int PageCount { get; }
    }
}