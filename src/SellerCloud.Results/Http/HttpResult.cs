using System;
using System.Net;
using System.Text;

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

        public string? BodyAsString()
        {
            return this.BodyAsString(Encoding.Default);
        }

        public string? BodyAsString(Encoding encoding)
        {
            if (encoding is null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            if (this.Body is null)
            {
                return default;
            }

            return encoding.GetString(this.Body);
        }
    }
}
