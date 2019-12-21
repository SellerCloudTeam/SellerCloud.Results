using System;

namespace SellerCloud.Results
{
    public static class ResultFactory
    {
        public static Result Success() => new Result();
        public static Result Error(string message) => new Result(errorMessage: message);
        public static Result Error(Exception exception) => new Result(errorMessage: exception.Message, errorSource: exception.StackTrace);

        public static Result<TData> Success<TData>(TData data) => new Result<TData>(data);
        public static Result<TData> Error<TData>(string message) => new Result<TData>(errorMessage: message);
        public static Result<TData> Error<TData>(string message, string source) => new Result<TData>(errorMessage: message, errorSource: source);
        public static Result<TData> Error<TData>(Exception exception) => new Result<TData>(errorMessage: exception.Message, errorSource: exception.StackTrace);
    }
}
