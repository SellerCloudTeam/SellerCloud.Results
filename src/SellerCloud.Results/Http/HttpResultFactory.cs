using System;
using System.Net;

namespace SellerCloud.Results.Http
{
    public static class HttpResultFactory
    {
        // Abstract results
        public static HttpResult Success(HttpStatusCode statusCode)
            => new HttpResult(statusCode);

        public static HttpResult Error(HttpStatusCode statusCode, string message)
            => new HttpResult(statusCode, message);

        public static HttpResult Error(HttpStatusCode statusCode, string message, string? source)
            => new HttpResult(statusCode, message, source);

        public static HttpResult Error(HttpStatusCode statusCode, Exception exception)
            => new HttpResult(statusCode, exception.Message, exception.StackTrace);

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
