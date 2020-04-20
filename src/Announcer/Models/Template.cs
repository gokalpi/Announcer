using Announcer.Contracts;
using System;
using System.Collections.Generic;

namespace Announcer.Models
{
    /// <summary>
    /// Template entity definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class Template : AuditableEntity, ISoftDelete
    {
        public Template()
        {
        }

        public Template(int id, string name, string content, bool isDeleted = false)
        {
            Id = id;
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            Content = content;
            IsDeleted = isDeleted;
        }

        /// <summary>
        /// Template Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of Template
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Content of Template
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Template soft deleted?
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Clients using this Template
        /// </summary>
        public virtual ICollection<Client> Clients { get; set; }
    }
}