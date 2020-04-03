using Announcer.Contracts.v1;
using System;
using System.Collections.Generic;

namespace Announcer.Models.v1
{
    /// <summary>
    /// Template entity definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class Template : AuditableEntity, ISoftDelete
    {
        public Template()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Template(string id, string name, string content) : base()
        {
            Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            Content = content;
        }

        /// <summary>
        /// Template Id
        /// </summary>
        public string Id { get; set; }

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