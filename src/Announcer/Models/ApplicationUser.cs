using Microsoft.AspNetCore.Identity;

namespace Announcer.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Profile Image
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Client Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Client
        /// </summary>
        public virtual Client Client { get; set; }
    }
}