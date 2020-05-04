using System.ComponentModel.DataAnnotations;

namespace Announcer.Dtos.Requests
{
    /// <summary>
    /// GroupMember DTO definition used for create and update operations
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class SaveGroupMemberDTO
    {
        /// <summary>
        /// Group Id
        /// </summary>
        [Required]
        public int GroupId { get; set; }

        /// <summary>
        /// Client Id
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ClientId { get; set; }
    }
}