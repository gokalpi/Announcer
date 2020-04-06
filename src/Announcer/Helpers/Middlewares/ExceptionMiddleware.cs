using Announcer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Announcer.Helper.Middlewares
{
    public class ExceptionMiddleware
    {
        // Handle to the next Middleware in the pipeline
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            string message = "";
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }

            if (!httpContext.Response.HasStarted)
            {
                httpContext.Response.ContentType = "application/json";

                var response = new CustomException(message, httpContext.Response.StatusCode);
                await httpContext.Response.WriteAsync(response.ToString());
            }
        }
    }
}