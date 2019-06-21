using System.Threading.Tasks;

namespace SellerCloud.Results
{
    public abstract class Result
    {
        /// <summary>
        /// Gets whether the result has value.
        /// </summary>
        public virtual bool HasValue { get; }

        /// <summary>
        /// Gets the type of the result.
        /// </summary>
        public virtual ResultType Type { get; }

        /// <summary>
        /// Gets whether the result is successful.
        /// </summary>
        public virtual bool IsSuccessful { get; }

        public static Task<Result<T>> ResultAsync<T>(T value)
            => Task.FromResult(new Result<T>(value, ResultType.NoError));

        public static Task<Result<T>> NoDataAsync<T>()
            => Task.FromResult(new Result<T>(default(T), ResultType.NoData));

        public static Task<Result<T>> ValidationErrorAsync<T>()
            => Task.FromResult(new Result<T>(default(T), ResultType.ValidationError));

        public static Task<Result<T>> PermissionErrorAsync<T>()
            => Task.FromResult(new Result<T>(default(T), ResultType.PermissionError));
    }
}
