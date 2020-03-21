using SellerCloud.Results.Http;
using System.Threading.Tasks;

namespace SellerCloud.Results
{
    public static class HttpValueResultExtensions
    {
        public static async Task<T> ResolveOrThrow<T>(this Task<HttpValueResult<T>> resultTask)
            where T : struct
        {
            HttpValueResult<T> result = await resultTask;

            return result.ResolveOrThrow();
        }

        public static T ResolveOrThrow<T>(this HttpValueResult<T> result)
            where T : struct
        {
            result.ThrowIfUnsuccessful();

            return result.Data;
        }

        public static async Task<Result> GetSuccessOrErrorMessageAsync<T>(this Task<HttpValueResult<T>> resultTask)
            where T : struct
        {
            HttpValueResult<T> result = await resultTask;

            return result.GetSuccessOrErrorMessage();
        }

        public static Result GetSuccessOrErrorMessage<T>(this HttpValueResult<T> result)
            where T : struct
            => result.IsSuccessful
            ? ResultFactory.Success()
            : ResultFactory.Error(result.Message);
    }
}
