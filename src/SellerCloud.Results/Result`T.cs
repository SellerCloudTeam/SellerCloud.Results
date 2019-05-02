namespace SellerCloud.Results
{
    public class Result<T> : Result
    {
        internal Result(T data)
            : base(isSuccessful: true)
        {
            this.Data = data;
        }

        internal Result(string errorMessage, string errorSource = null)
            : base(errorMessage, errorSource)
        {
        }

        public T Data { get; }
    }
}
