using System.ComponentModel.DataAnnotations;

namespace Announcer.Dtos.Requests.v1
{
    /// <summary>
    /// Client DTO definition used for create and update operations
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class SaveClientDTO
    {
        /// <summary>
        /// Client Id
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description of client
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Template Id of client
        /// </summary>
        public string TemplateId { get; set; }
    }
}