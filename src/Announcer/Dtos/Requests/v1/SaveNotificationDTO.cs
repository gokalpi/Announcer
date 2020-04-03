using System.ComponentModel.DataAnnotations;

namespace Announcer.Dtos.Requests.v1
{
    /// <summary>
    /// Notification DTO definition used for create and update operations
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class SaveNotificationDTO
    {
        /// <summary>
        /// Content of notification
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// Sender Id of notification
        /// </summary>
        [Required]
        public string SenderId { get; set; }

        /// <summary>
        /// Group Id of notification
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// Recipient Id of notification
        /// </summary>
        public string RecipientId { get; set; }
    }
}