namespace Announcer.Models.v1
{
    /// <summary>
    /// Query parameters
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class QueryParams
    {
        /// <summary>
        /// Page index
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Get details of entity?
        /// </summary>
        public bool IsDetailRequired { get; set; } = false;
    }
}