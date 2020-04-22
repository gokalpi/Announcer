namespace Announcer.Models
{
    /// <summary>
    /// Group Notification definition used for sending
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class SendGroupNotification
    {
        /// <summary>
        /// Name of group
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Message of Group Notification
        /// </summary>
        public string Message { get; set; }
    }
}