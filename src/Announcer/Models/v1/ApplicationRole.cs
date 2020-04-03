using Microsoft.AspNetCore.Identity;

namespace Announcer.Models.v1
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() : base()
        {
            Id = System.Guid.NewGuid().ToString();
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
            Id = System.Guid.NewGuid().ToString();
        }
    }
}