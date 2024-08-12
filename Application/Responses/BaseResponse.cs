namespace Application.Responses
{
    public abstract class BaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        protected BaseResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {

            return statusCode switch
            {
                200 => "Success",
                400 => "Bad Request",
                500 => "Internal Server Error",
                _ => string.Empty,
            };
        }
    }
}
