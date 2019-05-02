namespace SellerCloud.Results
{
    public class Result
    {
        internal Result(bool isSuccessful)
        {
            this.IsSuccessful = isSuccessful;
        }

        internal Result(string errorMessage, string errorSource = null)
        {
            this.IsSuccessful = false;
            this.Message = errorMessage;
            this.Source = errorSource;
        }

        public bool IsSuccessful { get; }
        public string Message { get; }
        public string Source { get; }
    }
}
