using Announcer.Contracts;
using System;

namespace Announcer.Models
{
    /// <summary>
    /// Setting entity definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class Setting : AuditableEntity, ISoftDelete
    {
        public Setting()
        {
        }

        public Setting(int id, string key, string value)
        {
            Id = id;
            Key = string.IsNullOrEmpty(key) ? throw new ArgumentNullException(nameof(key)) : key;
            Value = string.IsNullOrEmpty(value) ? throw new ArgumentNullException(nameof(value)) : value;
        }

        /// <summary>
        /// Setting Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Key of setting
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Value of setting
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Setting soft deleted?
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}