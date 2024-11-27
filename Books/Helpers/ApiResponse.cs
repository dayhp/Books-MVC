using Newtonsoft.Json;

namespace Books.Helpers
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public string Code { get; }

        public ApiResponse(int statusCode, string message = null, string code = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Code = code;
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Resource not found";

                case 500:
                    return "An unhandled error occurred";

                default:
                    return null;
            }
        }
    }
}
