using Announcer.Contracts;
using System;

namespace Announcer.Models
{
    /// <summary>
    /// Auditing entity
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public abstract class AuditableEntity : IAuditableEntity
    {
        /// <summary>
        /// User created the entity
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Created time of the entity
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// User last modified the entity
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Last modified time of the entity
        /// </summary>
        public DateTime? LastModifiedAt { get; set; }
    }
}