namespace API.Errors
{
    public class ApiException
    {
        public ApiException(int statusCode, string message = null, string details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        // what we're going to be returning for any exceptions, we get in our application

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}