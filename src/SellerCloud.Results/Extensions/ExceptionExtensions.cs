using System;

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
    }
}
