using System.ComponentModel.DataAnnotations;

namespace Announcer.Dtos.Requests
{
    /// <summary>
    /// Group DTO definition used for create and update operations
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class SaveGroupDTO
    {
        /// <summary>
        /// Name of group
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description of group
        /// </summary>
        public string Description { get; set; }
    }
}