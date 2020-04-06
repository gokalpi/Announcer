using Announcer.Contracts;
using System;
using System.Collections.Generic;

namespace Announcer.Models
{
    /// <summary>
    /// Group entity definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class Group : AuditableEntity, ISoftDelete
    {
        public Group()
        {
            Id = Guid.NewGuid().ToString();
            Clients = new HashSet<GroupMember>();
            NotificationsReceived = new HashSet<Notification>();
        }

        public Group(string id, string name, string description) : base()
        {
            Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            Description = description;
        }

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
        /// Clients belonging to the group
        /// </summary>
        public virtual ICollection<GroupMember> Clients { get; set; }

        /// <summary>
        /// Notifications received by group
        /// </summary>
        public virtual ICollection<Notification> NotificationsReceived { get; set; }
    }
}