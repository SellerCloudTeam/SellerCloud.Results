using System;
using System.Collections.Generic;
using System.Linq;

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

        public static Result From(Action action)
        {
            try
            {
                action();

                return Success();
            }
            catch (Exception ex)
            {
                return ex.AsResult();
            }
        }

        public static Result<T> From<T>(Func<T> func)
        {
            try
            {
                T value = func();

                return Success(value);
            }
            catch (Exception ex)
            {
                return ex.AsResult<T>();
            }
        }

        public static Result<TResult> From<T, TResult>(Func<T> func, Func<T, TResult> map)
        {
            try
            {
                T value = func();
                TResult mapped = map(value);

                return Success(mapped);
            }
            catch (Exception ex)
            {
                return ex.AsResult<TResult>();
            }
        }

        public static Result<IEnumerable<TResult>> From<T, TResult>(Func<IEnumerable<T>> func, Func<T, TResult> map)
        {
            try
            {
                IEnumerable<T> source = func();
                IEnumerable<TResult> mapped = source.Select(map).ToList();

                return Success(mapped);
            }
            catch (Exception ex)
            {
                return ex.AsResult<IEnumerable<TResult>>();
            }
        }
    }
}
