using Announcer.Helper.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Announcer.Helpers.Extensions
{
    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }
    }
}