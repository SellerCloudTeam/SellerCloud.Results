using SellerCloud.Results.Http;
using System;
using System.Net;

namespace SellerCloud.Results
{
    /// <summary>
    /// Contains static extension methods for <see cref="System.Exception"/>, which wraps it in <see cref="Result{T}"/>/<see cref="Result"/>.
    /// </summary>
    public static class ExceptionExtensions
    {
        public static Result AsResult(this Exception exception)
            => ResultFactory.Error(exception);

        public static Result<T> AsResult<T>(this Exception exception)
            where T : class
            => ResultFactory.Error<T>(exception);

        public static ValueResult<T> AsValueResult<T>(this Exception exception)
            where T : struct
            => ValueResultFactory.Error<T>(exception);

        public static HttpResult AsHttpResult(this Exception exception, HttpStatusCode statusCode)
            => HttpResultFactory.Error(statusCode, exception);

        public static HttpResult<T> AsHttpResult<T>(this Exception exception, HttpStatusCode statusCode)
            where T : class
            => HttpResultFactory.Error<T>(statusCode, exception);

        public static HttpValueResult<T> AsHttpValueResult<T>(this Exception exception, HttpStatusCode statusCode)
            where T : struct
            => HttpValueResultFactory.Error<T>(statusCode, exception);
    }
}
