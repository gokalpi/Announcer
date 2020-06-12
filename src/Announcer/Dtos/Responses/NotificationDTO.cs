using System;

namespace Announcer.Dtos.Responses
{
    /// <summary>
    /// Notification DTO definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class NotificationDTO
    {
        /// <summary>
        /// Notification Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Content of notification
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Sender of notification
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Sent time of notification
        /// </summary>
        public DateTime SentTime { get; set; }

        /// <summary>
        /// Group of notification
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Recipient of notification
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Notification soft deleted?
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}