using SellerCloud.Results.Http;
using System.Threading.Tasks;

namespace SellerCloud.Results
{
    public static class HttpResultExtensions
    {
        public static async Task<T> ResolveOrThrow<T>(this Task<HttpResult<T>> resultTask)
            where T : class
        {
            HttpResult<T> result = await resultTask;

            return result.ResolveOrThrow();
        }

        public static T ResolveOrThrow<T>(this HttpResult<T> result)
            where T : class
        {
            result.ThrowIfUnsuccessful();

            return result.Data;
        }

        public static async Task<Result> GetSuccessOrErrorMessageAsync<T>(this Task<HttpResult<T>> resultTask)
            where T : class
        {
            HttpResult<T> result = await resultTask;

            return result.GetSuccessOrErrorMessage();
        }

        public static Result GetSuccessOrErrorMessage<T>(this HttpResult<T> result)
            where T : class
            => result.IsSuccessful
            ? ResultFactory.Success()
            : ResultFactory.Error(result.Message);
    }
}
