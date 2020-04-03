using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Net;

namespace Announcer.Pages
{
    public class NotificationsModel : PageModel
    {
        public string ClientIP { get; set; }

        public void OnGet()
        {
            string header = HttpContext.Request.Headers["CF-Connecting-IP"].FirstOrDefault() ?? HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if  (IPAddress.TryParse(header?.Split(":")[0], out IPAddress ip))
            {
                ClientIP = ip.ToString();
            }
            else
            {
                ClientIP = HttpContext?.Connection?.RemoteIpAddress?.ToString();
            }

            ClientIP = (ClientIP == "::1") ? "" : ClientIP; 
        }
    }
}