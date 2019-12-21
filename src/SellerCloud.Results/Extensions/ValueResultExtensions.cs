using System.Threading.Tasks;

namespace SellerCloud.Results
{
    public static class ValueResultExtensions
    {
        public static async Task<T> ResolveOrThrow<T>(this Task<ValueResult<T>> resultTask)
            where T : struct
        {
            ValueResult<T> result = await resultTask;

            return result.ResolveOrThrow();
        }

        public static T ResolveOrThrow<T>(this ValueResult<T> result)
            where T : struct
        {
            result.ThrowIfUnsuccessful();

            return result.Data;
        }
    }
}
