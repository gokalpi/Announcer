using System.Collections.Generic;

namespace Announcer.Dtos.Responses.v1
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
        /// Clients of group
        /// </summary>
        public ICollection<GroupMemberDTO> Clients { get; set; }

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