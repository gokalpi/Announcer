using System;

namespace Announcer.Contracts.v1
{
    /// <summary>
    /// Auditing entity interface
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface IAuditableEntity : IEntity
    {
        /// <summary>
        /// User created the entity
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Created time of the entity
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// User last modified the entity
        /// </summary>
        string LastModifiedBy { get; set; }

        /// <summary>
        /// Last modified time of the entity
        /// </summary>
        DateTime? LastModifiedAt { get; set; }
    }
}