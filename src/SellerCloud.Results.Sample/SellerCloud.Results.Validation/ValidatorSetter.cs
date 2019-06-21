using SellerCloud.Results.Validation.Abstractions;
using System;

namespace SellerCloud.Results.Validation
{
    /// <summary>
    /// Setter that specify what rule will be used.
    /// </summary>
    /// <typeparam name="TParam">The type of the parameter.</typeparam>
    public class ValidatorSetter<TParam>
    {
        /// <summary> Gets the type of the rule.</summary>
        public Type RuleType { get; private set; }

        /// <summary>Specify what rule will be used.</summary>
        public void Use<TRule>()
            where TRule : IValidationRule<TParam>
                => RuleType = typeof(TRule);
    }
}
