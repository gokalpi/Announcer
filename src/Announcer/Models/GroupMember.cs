using System;

namespace Announcer.Models
{
    /// <summary>
    /// GroupMember entity definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class GroupMember : AuditableEntity
    {
        public GroupMember()
        {
        }

        public GroupMember(int groupId, string clientId)
        {
            GroupId = groupId;
            ClientId = string.IsNullOrEmpty(clientId) ? throw new ArgumentNullException(nameof(clientId)) : clientId;
        }

        /// <summary>
        /// Group Id
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Client Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public virtual Group Group { get; set; }

        /// <summary>
        /// Client
        /// </summary>
        public virtual Client Client { get; set; }
    }
}