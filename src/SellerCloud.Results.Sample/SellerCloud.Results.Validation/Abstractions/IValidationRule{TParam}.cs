using System.Threading.Tasks;

namespace SellerCloud.Results.Validation.Abstractions
{
    /// <summary>
    /// The validation rule typed interface.
    /// </summary>
    /// <typeparam name="TParam">The type of the parameter.</typeparam>
    public interface IValidationRule<TParam>
    {
        /// <summary>
        /// Validate the specified parameter.
        /// </summary>
        /// <param name="parameters">The parameter to be validate.</param>
        /// <returns>If the parameter is valid return [true].</returns>
        Task<bool> Validate(TParam parameters);
    }
}
