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
        public string Id { get; set; }

        /// <summary>
        /// Name of group
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Content of group
        /// </summary>
        public string Content { get; set; }
    }
}