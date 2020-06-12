namespace Announcer.Dtos.Responses
{
    /// <summary>
    /// Setting DTO definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class SettingDTO
    {
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