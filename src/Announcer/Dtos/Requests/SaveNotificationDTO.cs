﻿using System.ComponentModel.DataAnnotations;

namespace Announcer.Dtos.Requests
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
        [MaxLength(50)]
        public string SenderId { get; set; }

        /// <summary>
        /// Group Id of notification
        /// </summary>
        [MaxLength(50)]
        public int GroupId { get; set; }

        /// <summary>
        /// Recipient Id of notification
        /// </summary>
        [MaxLength(50)]
        public string RecipientId { get; set; }
    }
}