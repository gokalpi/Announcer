﻿using Announcer.Contracts;
using System;
using System.Collections.Generic;

namespace Announcer.Models
{
    /// <summary>
    /// Client entity definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class Client : AuditableEntity, ISoftDelete
    {
        public Client()
        {
        }

        public Client(string id, string name, string description, string userId, int templateId, bool isDeleted = false)
        {
            Id = string.IsNullOrEmpty(id) ? throw new ArgumentNullException(nameof(id)) : id;
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            UserId = userId;
            TemplateId = templateId;
            Description = description;
            IsDeleted = isDeleted;
        }

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
        /// User Id of client
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Template Id of client
        /// </summary>
        public int TemplateId { get; set; }

        /// <summary>
        /// Client soft deleted?
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// Template of client
        /// </summary>
        public virtual Template Template { get; set; }

        /// <summary>
        /// Groups client subscribed to
        /// </summary>
        public virtual ICollection<GroupMember> Groups { get; set; } = new HashSet<GroupMember>();

        /// <summary>
        /// Notifications sent by client
        /// </summary>
        public virtual ICollection<Notification> NotificationsSent { get; set; } = new HashSet<Notification>();

        /// <summary>
        /// Notifications received by client
        /// </summary>
        public virtual ICollection<Notification> NotificationsReceived { get; set; } = new HashSet<Notification>();
    }
}