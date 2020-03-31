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

        internal Result(string message, string? source = null)
        {
            this.IsSuccessful = false;

            // Error-related properties
            this.Message = message;
            this.Source = source;
        }

        public bool IsSuccessful { get; }

        public string Message { get; }

        public string? Source { get; }
    }
}
