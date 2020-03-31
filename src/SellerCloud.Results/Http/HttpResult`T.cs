using System.Net;

namespace SellerCloud.Results.Http
{
    public class HttpResult<T> : Result<T>
        where T : class
    {
        internal HttpResult(HttpStatusCode statusCode, T data)
            : base(data)
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
