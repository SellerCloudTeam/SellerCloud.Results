using System;

namespace SellerCloud.Results
{
    public static class ValueResultFactory
    {
        // Results of value type
        public static ValueResult<TData> Success<TData>(TData data)
            where TData : struct
            => new ValueResult<TData>(data);

        public static ValueResult<TData> Error<TData>(string message)
            where TData : struct
            => new ValueResult<TData>(message);

        public static ValueResult<TData> Error<TData>(string message, string? source)
            where TData : struct
            => new ValueResult<TData>(message, source);

        public static ValueResult<TData> Error<TData>(Exception exception)
            where TData : struct
            => new ValueResult<TData>(exception.Message, exception.StackTrace);
    }
}
