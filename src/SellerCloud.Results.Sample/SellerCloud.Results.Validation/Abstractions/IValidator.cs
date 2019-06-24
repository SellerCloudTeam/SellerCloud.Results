using System;
using System.Threading.Tasks;

namespace SellerCloud.Results.Validation.Abstractions
{
    /// <summary>
    /// Validator that validate model.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Adds the validation rule.
        /// </summary>
        /// <typeparam name="TParam">The type of the parameters.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="validatorSetter">The setter that specify the rule class.</param>
        /// <param name="canBrake">if set to <c>true</c> [brake and do not continue].</param>
        IValidator AddRule<TParam>(TParam parameters, Action<ValidatorSetter<TParam>> validatorSetter, bool canBrake = true);

        /// <summary>
        /// Adds the validation rule.
        /// </summary>
        /// <typeparam name="TRule">The type of the rule.</typeparam>
        /// <param name="parameters">The parameters.</param>
        IValidator AddRule<TRule>(dynamic parameters);

        /// <summary>
        /// Adds the validation rule.
        /// </summary>
        /// <typeparam name="TRule">The type of the rule.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="canBrake">if set to <c>true</c> [can brake].</param>
        IValidator AddRule<TRule>(dynamic parameters, bool canBrake)
            where TRule : IValidationRule;

        /// <summary>
        /// Validate the provided model by a set of properties.
        /// </summary>
        Task<ValidationResult> ValidateAsync();
    }
}
