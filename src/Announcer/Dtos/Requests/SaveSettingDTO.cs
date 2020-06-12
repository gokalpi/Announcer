using System.ComponentModel.DataAnnotations;

namespace Announcer.Dtos.Requests
{
    /// <summary>
    /// Setting DTO definition used for create and update operations
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class SaveSettingDTO
    {
        /// <summary>
        /// Key of settings
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Key { get; set; }

        /// <summary>
        /// Value of settings
        /// </summary>
        [Required]
        public string Value { get; set; }
    }
}