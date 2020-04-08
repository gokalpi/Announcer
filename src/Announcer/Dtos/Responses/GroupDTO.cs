using System.Collections.Generic;

namespace Announcer.Dtos.Responses
{
    /// <summary>
    /// Group DTO definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class GroupDTO
    {
        /// <summary>
        /// Group Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of group
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of group
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Group soft deleted?
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Number of clients in group
        /// </summary>
        public int ClientCount { get; set; }

        /// <summary>
        /// Number of notifications received by group
        /// </summary>
        public int NotificationsReceivedCount { get; set; }

        /// <summary>
        /// Clients of group
        /// </summary>
        public ICollection<GroupMemberDTO> Clients { get; set; }

        /// <summary>
        /// Notifications received by client
        /// </summary>
        public ICollection<NotificationDTO> NotificationsReceived { get; set; }
    }
}