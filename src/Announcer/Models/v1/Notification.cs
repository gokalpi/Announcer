using Announcer.Contracts.v1;
using System;

namespace Announcer.Models.v1
{
    /// <summary>
    /// Notification entity definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class Notification : AuditableEntity, ISoftDelete
    {
        public Notification()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Notification(string id, string content, string senderId, DateTime sentTime, string groupId = null, string recipientId = null) : base()
        {
            Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
            Content = string.IsNullOrEmpty(content) ? throw new ArgumentNullException(nameof(content)) : content;
            SenderId = string.IsNullOrEmpty(senderId) ? throw new ArgumentNullException(nameof(senderId)) : senderId;
            SentTime = sentTime;
            GroupId = groupId;
            RecipientId = recipientId;
        }

        /// <summary>
        /// Notification Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Content of notification
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Sender Id of notification
        /// </summary>
        public string SenderId { get; set; }

        /// <summary>
        /// Sent time of notification
        /// </summary>
        public DateTime SentTime { get; set; }

        /// <summary>
        /// Group Id of notification
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// Recipient Id of notification
        /// </summary>
        public string RecipientId { get; set; }

        /// <summary>
        /// Notification soft deleted?
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Sender of notification
        /// </summary>
        public virtual Client Sender { get; set; }

        /// <summary>
        /// Group of notification
        /// </summary>
        public virtual Group Group { get; set; }

        /// <summary>
        /// Recipient of notification
        /// </summary>
        public virtual Client Recipient { get; set; }
    }
}