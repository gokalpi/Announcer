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
        }

        public Group(int id, string name, string description, bool isDeleted = false)
        {
            Id = id;
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            Description = description;
            IsDeleted = isDeleted;
        }

        /// <summary>
        /// Group Id
        /// </summary>
        public int Id { get; set; }

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
        public virtual ICollection<GroupMember> Clients { get; set; } = new HashSet<GroupMember>();

        /// <summary>
        /// Notifications received by group
        /// </summary>
        public virtual ICollection<Notification> NotificationsReceived { get; set; } = new HashSet<Notification>();
    }
}