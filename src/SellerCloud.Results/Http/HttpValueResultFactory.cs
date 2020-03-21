using System;
using System.Net;

namespace SellerCloud.Results.Http
{
    public static class HttpValueResultFactory
    {
        // Results of value type
        public static HttpValueResult<T> Success<T>(HttpStatusCode statusCode, T data)
            where T : struct
            => new HttpValueResult<T>(statusCode, data);

        public static HttpValueResult<T> Error<T>(HttpStatusCode statusCode, string message)
            where T : struct
            => new HttpValueResult<T>(statusCode, message);

        public static HttpValueResult<T> Error<T>(HttpStatusCode statusCode, string message, string? source)
            where T : struct
            => new HttpValueResult<T>(statusCode, message, source);

        public static HttpValueResult<T> Error<T>(HttpStatusCode statusCode, Exception exception)
            where T : struct
            => new HttpValueResult<T>(statusCode, exception.Message, exception.StackTrace);
    }
}
