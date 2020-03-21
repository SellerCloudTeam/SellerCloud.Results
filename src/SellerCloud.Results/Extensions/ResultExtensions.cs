using System;
using System.Threading.Tasks;

namespace SellerCloud.Results
{
    public static class ResultExtensions
    {
        public static string ToFullErrorString(this Result result)
        {
            if (string.IsNullOrWhiteSpace(result.Source)) return result.Message;

            return $"{result.Message}\r\n\r\n{result.Source}";
        }

        public static async Task<T> ResolveOrThrow<T>(this Task<Result<T>> resultTask)
            where T : class
        {
            Result<T> result = await resultTask;

            return result.ResolveOrThrow();
        }

        public static T ResolveOrThrow<T>(this Result<T> result)
            where T : class
        {
            result.ThrowIfUnsuccessful();

            return result.Data;
        }

        public static void ThrowIfUnsuccessful(this Result result)
        {
            if (!result.IsSuccessful)
            {
                throw result.AsException();
            }
        }

        private static ApplicationException AsException(this Result result)
        {
            string message = result.ToFullErrorString();

            return new ApplicationException(message);
        }

        public static async Task<Result> GetSuccessOrErrorMessageAsync<T>(this Task<Result<T>> resultTask)
        {
            Result<T> result = await resultTask;

            return result.GetSuccessOrErrorMessage();
        }

        public static Result GetSuccessOrErrorMessage<T>(this Result<T> result)
            => result.IsSuccessful
            ? ResultFactory.Success()
            : ResultFactory.Error(result.Message);
    }
}
