using System;
using System.Collections.Generic;
using System.Linq;

namespace SellerCloud.Results
{
    public static class ResultFactory
    {
        // Abstract results
        public static Result Success()
            => new Result();

        public static Result Error(string message)
            => new Result(message);

        public static Result Error(string message, string? source)
            => new Result(message, source);

        public static Result Error(Exception exception)
            => new Result(exception.Message, exception.StackTrace);

        // Results of reference type
        public static Result<T> Success<T>(T data)
            where T : class
            => new Result<T>(data);

        public static Result<T> Error<T>(string message)
            where T : class
            => new Result<T>(message);

        public static Result<T> Error<T>(string message, string? source)
            where T : class
            => new Result<T>(message, source);

        public static Result<T> Error<T>(Exception exception)
            where T : class
            => new Result<T>(exception.Message, exception.StackTrace);

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
            where T : class
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
            where TResult : class
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
