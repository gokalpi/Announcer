using Newtonsoft.Json;

namespace Announcer.Models
{
    /// <summary>
    /// ErrorDetails entity definition used in exception handling
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public class CustomException
    {
        public CustomException(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public string Message { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}