using System.Net;

namespace SellerCloud.Results.Http
{
    public class HttpResult : Result
    {
        internal HttpResult(HttpStatusCode statusCode, byte[]? body = null)
        {
            this.StatusCode = statusCode;
            this.Body = body;
        }

        internal HttpResult(HttpStatusCode statusCode, string message, string? source = null, byte[]? body = null)
            : base(message, source)
        {
            this.StatusCode = statusCode;
            this.Body = body;
        }

        public HttpStatusCode StatusCode { get; }

        public byte[]? Body { get; }
    }
}
