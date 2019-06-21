using SellerCloud.Results.Validation.Abstractions;
using System.Threading.Tasks;

namespace SellerCloud.Results.Sample.Rules
{
    /// <summary>
    /// The identifier should be positive rule.
    /// </summary>
    public class IdentifierShouldBePositive : ValidationRule<long>
    {
        #region Validation Methods

        /// <see cref="IValidationRule{TParam}.Validate(TParam)"/> for more.
        public override Task<bool> Validate(long parameter)
        {
            bool valid = SetErrorIfInvalid(parameter > 0L, "INVALID_DATA", ResultType.ValidationError);

            return Task.FromResult(valid);
        }

        #endregion
    }
}
