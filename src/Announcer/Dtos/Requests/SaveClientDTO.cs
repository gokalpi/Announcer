using System.ComponentModel.DataAnnotations;

namespace Announcer.Dtos.Requests
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
        [MaxLength(50)]
        public string Id { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Description of client
        /// </summary>
        [MaxLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// Template Id of client
        /// </summary>
        public int TemplateId { get; set; }
    }
}