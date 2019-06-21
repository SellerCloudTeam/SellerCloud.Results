namespace SellerCloud.Results.Validation
{
    /// <summary>
    /// Validation model class.
    /// </summary>
    public class ValidationModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationModel"/> class.
        /// </summary>
        /// <param name="validationKey">The validation key.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="canBreak">if set to <c>true</c> [can break].</param>
        public ValidationModel(string validationKey, object parameters, bool canBreak)
        {
            ValidationKey = validationKey;
            Parameters = parameters;
            CanBreak = canBreak;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the validation key.
        /// </summary>
        public string ValidationKey { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public object Parameters { get; }

        /// <summary>
        /// Gets a value indicating whether this instance can break.
        /// </summary>
        public bool CanBreak { get; }

        #endregion
    }
}
