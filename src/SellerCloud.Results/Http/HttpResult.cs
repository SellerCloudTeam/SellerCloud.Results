using System.Net;

namespace SellerCloud.Results.Http
{
    public class HttpResult : Result
    {
        internal HttpResult(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        internal HttpResult(HttpStatusCode statusCode, string message, string? source = null)
            : base(message, source)
        {
            this.StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}
