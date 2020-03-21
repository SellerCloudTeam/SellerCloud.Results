using System;

namespace SellerCloud.Results
{
    public static class ValueResultFactory
    {
        // Results of value type
        public static ValueResult<T> Success<T>(T data)
            where T : struct
            => new ValueResult<T>(data);

        public static ValueResult<T> Error<T>(string message)
            where T : struct
            => new ValueResult<T>(message);

        public static ValueResult<T> Error<T>(string message, string? source)
            where T : struct
            => new ValueResult<T>(message, source);

        public static ValueResult<T> Error<T>(Exception exception)
            where T : struct
            => new ValueResult<T>(exception.Message, exception.StackTrace);

        public static ValueResult<T> From<T>(Func<T> func)
            where T : struct
        {
            try
            {
                T value = func();

                return Success(value);
            }
            catch (Exception ex)
            {
                return ex.AsValueResult<T>();
            }
        }

        public static ValueResult<TResult> From<T, TResult>(Func<T> func, Func<T, TResult> map)
            where TResult : struct
        {
            try
            {
                T value = func();
                TResult mapped = map(value);

                return Success(mapped);
            }
            catch (Exception ex)
            {
                return ex.AsValueResult<TResult>();
            }
        }
    }
}
