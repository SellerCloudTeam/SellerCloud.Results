namespace SellerCloud.Results
{
    public class ValueResult<T> : Result
        where T : struct
    {
        internal ValueResult(T data)
        {
            this.Data = data;
        }

        internal ValueResult(string message, string? source = null)
            : base(message, source)
        {
            this.Data = default!;
        }

        public T Data { get; }
    }
}
