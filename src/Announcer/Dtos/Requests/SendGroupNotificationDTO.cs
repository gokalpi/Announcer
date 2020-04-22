using System.ComponentModel.DataAnnotations;

namespace Announcer.Dtos.Requests
{
    /// <summary>
    /// Group Notification DTO definition used for sending
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class SendGroupNotificationDTO
    {
        /// <summary>
        /// Name of group
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string GroupName { get; set; }

        /// <summary>
        /// Message of Group Notification
        /// </summary>
        [Required]
        public string Message { get; set; }
    }
}