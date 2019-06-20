using System.Collections.Generic;
using System.Threading.Tasks;

namespace SellerCloud.Results
{
    public class Result<T>
    {
        public T Value { get; }

        public bool HasValue => !EqualityComparer<T>.Default.Equals(Value, default(T));

        public ResultType Type { get; set; }

        public bool IsSuccess
            => Type == ResultType.NoError
            || Type == ResultType.NoData;

        public Result(T value, ResultType resultType)
        {
            Value = value;
            Type = resultType;
        }

        public static Task<Result<T>> Fail<T>(T value, ResultType resultType)
        {
            return Task.FromResult(new Result<T>(value, resultType));
        }
    }
}
