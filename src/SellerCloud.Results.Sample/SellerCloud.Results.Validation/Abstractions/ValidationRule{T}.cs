using System.Threading.Tasks;

namespace SellerCloud.Results.Validation.Abstractions
{
    /// <summary>
    /// The validation rule with parsed parameters.
    /// </summary>
    /// <seealso cref="Questar.Identity.Business.Validation.Core.IValidationRule" />
    public abstract class ValidationRule<T> : IValidationRule, IValidationRule<T>
    {
        /// <see cref="IValidationRule"/> for more.
        public virtual ValidationError Error { get; protected set; }

        /// <see cref="IValidationRule"/> for more.
        public virtual Task<bool> Validate(dynamic parameters) =>
            parameters is T ?
            Validate((T)parameters) :
            Task.FromResult(SetErrorIfInvalid(false, "NOT_PARSED_PARAMETERS", ResultType.ValidationError));

        /// <summary>
        /// Validates the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter to be validate.</param>
        /// <returns>Returns true if valid.</returns>
        public abstract Task<bool> Validate(T parameter);

        /// <summary>
        /// Sets the error if invalid.
        /// </summary>
        /// <param name="valid">if set to <c>true</c> [valid].</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="errorCode">The error code.</param>
        protected bool SetErrorIfInvalid(bool valid, string errorMessage, ResultType resultType)
        {
            if (!valid)
            {
                Error = new ValidationError(errorMessage, resultType);
            }

            return valid;
        }
    }
}
