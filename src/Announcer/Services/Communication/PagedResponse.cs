using Announcer.Contracts;

namespace Announcer.Services.Communication
{
    /// <summary>
    /// Paged list of entity response interface for service communications
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class PagedResponse<T> : ListResponse<T>, IPagedResponse<T>
    {
        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Page number
        /// </summary>
        public int PageNumber { get; set; }

        /// <inheritdoc/>
        public long TotalItems { get; set; }

        /// <inheritdoc/>
        public int PageCount
            => (PageSize == 0) ? 0 : (TotalItems < PageSize) ? 1 : (int)(((double)TotalItems / PageSize) + 1);
    }
}