namespace SellerCloud.Results.Validation
{
    /// <summary>
    /// Validation error model.
    /// </summary>
    public class ValidationError
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationError"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errorCode">The error code.</param>
        public ValidationError(string message, ResultType errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }

        #endregion

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public ResultType ErrorCode { get; }
    }
}
