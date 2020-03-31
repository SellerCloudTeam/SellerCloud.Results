using System.Net;

namespace SellerCloud.Results.Http
{
    public class HttpValueResult<T> : ValueResult<T>
        where T : struct
    {
        internal HttpValueResult(HttpStatusCode statusCode, T data)
            : base(data)
        {
            this.StatusCode = statusCode;
        }

        internal HttpValueResult(HttpStatusCode statusCode, string message, string? source = null)
            : base(message, source)
        {
            this.StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}
