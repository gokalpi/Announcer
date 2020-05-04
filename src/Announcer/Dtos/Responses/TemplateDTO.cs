namespace Announcer.Dtos.Responses
{
    /// <summary>
    /// Template DTO definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class TemplateDTO
    {
        /// <summary>
        /// Template Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of Template
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Content of Template
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Number of clients using Template
        /// </summary>
        public int ClientCount { get; set; }

        /// <summary>
        /// Template soft deleted?
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}