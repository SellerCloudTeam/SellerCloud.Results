namespace SellerCloud.Results
{
    public class Result
    {
        internal Result()
        {
            this.IsSuccessful = true;

            // Error-related properties
            this.Message = default!;
            this.Source = null;
        }

        internal Result(string errorMessage, string? errorSource = null)
        {
            this.IsSuccessful = false;

            // Error-related properties
            this.Message = errorMessage;
            this.Source = errorSource;
        }

        public bool IsSuccessful { get; }
        public string Message { get; }
        public string? Source { get; }
    }
}
