using System;

namespace SellerCloud.Results
{
    public static class ResultFactory
    {
        // Abstract results
        public static Result Success()
            => new Result();

        public static Result Error(string message)
            => new Result(message);

        public static Result Error(string message, string source)
            => new Result(message, source);

        public static Result Error(Exception exception)
            => new Result(exception.Message, exception.StackTrace);

        // Results of reference type
        public static Result<TData> Success<TData>(TData data)
            where TData : class
            => new Result<TData>(data);

        public static Result<TData> Error<TData>(string message)
            where TData : class
            => new Result<TData>(message);

        public static Result<TData> Error<TData>(string message, string source)
            where TData : class
            => new Result<TData>(message, source);

        public static Result<TData> Error<TData>(Exception exception)
            where TData : class
            => new Result<TData>(exception.Message, exception.StackTrace);
    }
}
