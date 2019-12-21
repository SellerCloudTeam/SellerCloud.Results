namespace SellerCloud.Results
{
    public class Result<T> : Result
    {
        internal Result(T data)
        {
            this.Data = data;
        }

        internal Result(string errorMessage, string? errorSource = null)
            : base(errorMessage, errorSource)
        {
            this.Data = default!;
        }

        public T Data { get; }
    }
}
