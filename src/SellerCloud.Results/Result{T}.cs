using System.Collections.Generic;

namespace SellerCloud.Results
{
    public class Result<T> : Result
    {
        public T Value { get; }

        public override bool HasValue => !EqualityComparer<T>.Default.Equals(Value, default(T));

        public override ResultType Type { get; }

        public override bool IsSuccessful
            => Type == ResultType.NoError
            || Type == ResultType.NoData;

        public Result(T value, ResultType resultType)
        {
            Value = value;
            Type = resultType;
        }
    }
}
