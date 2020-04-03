using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Announcer.Areas.Identity.IdentityHostingStartup))]

namespace Announcer.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}