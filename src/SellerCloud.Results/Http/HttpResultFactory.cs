using System;
using System.Net;

namespace SellerCloud.Results.Http
{
    public static class HttpResultFactory
    {
        // Abstract results
        public static HttpResult Success(HttpStatusCode statusCode, byte[]? body = null)
            => new HttpResult(statusCode, body);

        public static HttpResult Error(HttpStatusCode statusCode, string message, byte[]? body = null)
            => new HttpResult(statusCode, message, source: null, body);

        public static HttpResult Error(HttpStatusCode statusCode, string message, string? source, byte[]? body = null)
            => new HttpResult(statusCode, message, source, body);

        public static HttpResult Error(HttpStatusCode statusCode, Exception exception, byte[]? body = null)
            => new HttpResult(statusCode, exception.Message, exception.StackTrace, body);

        // Results of reference type
        public static HttpResult<T> Success<T>(HttpStatusCode statusCode, T data)
            where T : class
            => new HttpResult<T>(statusCode, data);

        public static HttpResult<T> Error<T>(HttpStatusCode statusCode, string message)
            where T : class
            => new HttpResult<T>(statusCode, message);

        public static HttpResult<T> Error<T>(HttpStatusCode statusCode, string message, string? source)
            where T : class
            => new HttpResult<T>(statusCode, message, source);

        public static HttpResult<T> Error<T>(HttpStatusCode statusCode, Exception exception)
            where T : class
            => new HttpResult<T>(statusCode, exception.Message, exception.StackTrace);
    }
}
