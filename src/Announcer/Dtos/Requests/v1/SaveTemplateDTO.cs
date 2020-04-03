using System.ComponentModel.DataAnnotations;

namespace Announcer.Dtos.Requests.v1
{
    /// <summary>
    /// Template DTO definition used for create and update operations
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class SaveTemplateDTO
    {
        /// <summary>
        /// Name of group
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Content of group
        /// </summary>
        public string Content { get; set; }
    }
}