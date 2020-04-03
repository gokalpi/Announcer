using Announcer.Helpers.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Announcer.Helpers.Extensions
{
    public static class ResponseTimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseResponseTimeMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ResponseTimeMiddleware>();

            return app;
        }
    }
}