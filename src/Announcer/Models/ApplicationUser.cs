using Microsoft.AspNetCore.Identity;

namespace Announcer.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser() : base()
        {
            Id = System.Guid.NewGuid().ToString();
        }

        public ApplicationUser(string userName) : base(userName)
        {
            Id = System.Guid.NewGuid().ToString();
        }

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