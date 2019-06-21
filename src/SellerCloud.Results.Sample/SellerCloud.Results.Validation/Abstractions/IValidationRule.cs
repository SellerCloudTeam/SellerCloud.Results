using System.Threading.Tasks;

namespace SellerCloud.Results.Validation.Abstractions
{
    /// <summary>
    /// The validation rule interface.
    /// </summary>
    public interface IValidationRule
    {
        /// <summary>
        /// Gets the error.
        /// </summary>
        ValidationError Error { get; }

        /// <summary>
        /// Validate the specified model.
        /// </summary>
        /// <returns>If the model is valid.</returns>
        Task<bool> Validate(dynamic parameters);
    }
}
