using System.Collections.Generic;

namespace Announcer.Dtos.Responses
{
    /// <summary>
    /// Client DTO definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class ClientDTO
    {
        /// <summary>
        /// Client Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of client
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Template of client
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Client soft deleted?
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Number of groups subscribed by Client
        /// </summary>
        public int GroupCount { get; set; }

        /// <summary>
        /// Number of notifications sent by client
        /// </summary>
        public int NotificationsSentCount { get; set; }

        /// <summary>
        /// Number of notifications received by client
        /// </summary>
        public int NotificationsReceivedCount { get; set; }

        /// <summary>
        /// Groups client subscribed to
        /// </summary>
        public ICollection<GroupMemberDTO> Groups { get; set; }

        /// <summary>
        /// Notifications sent by client
        /// </summary>
        public ICollection<NotificationDTO> NotificationsSent { get; set; }

        /// <summary>
        /// Notifications received by client
        /// </summary>
        public ICollection<NotificationDTO> NotificationsReceived { get; set; }
    }
}