using Announcer.Contracts;
using System;

namespace Announcer.Services.Communication
{
    /// <summary>
    /// Paged list of entity response interface for service communications
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class PagedResponse<T> : ListResponse<T>, IPagedResponse<T>
    {
        private const int MAX_PAGE_SIZE = 50;

        private int _pageSize;

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value; }
        }

        private int _currentPage;

        /// <summary>
        /// Current page number
        /// </summary>
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value > TotalPages ? TotalPages : value; }
        }

        /// <inheritdoc/>
        public long TotalItems { get; set; }

        /// <inheritdoc/>
        public int TotalPages => (_pageSize > 0) ? (int)Math.Ceiling(TotalItems / (double)_pageSize) : 0;
    }
}