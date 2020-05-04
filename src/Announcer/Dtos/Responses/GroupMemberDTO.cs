namespace Announcer.Dtos.Responses
{
    /// <summary>
    /// GroupMember DTO definition
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class GroupMemberDTO
    {
        /// <summary>
        /// Group Id
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Group Name
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Client Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Client Name
        /// </summary>
        public string Client { get; set; }
    }
}