using Announcer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Announcer.Helpers.Extensions
{
    public static class ResponseExtensions
    {
        public static void SetError(this IResponse response, Exception exception, string exceptionOwner, ILogger logger)
        {
            response.IsSuccessful = false;

            var errorMessage = (exception.InnerException != null) ? exception.InnerException.Message : exception.Message;
            logger.LogError("There was an error on '{0}' invocation: {1}", exceptionOwner, errorMessage);
            response.Message = errorMessage;
        }

        public static IActionResult ToHttpResponse(this IResponse response)
        {
            var status = response.IsSuccessful ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (!response.IsSuccessful)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NotFound;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (!response.IsSuccessful)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NoContent;

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }
}