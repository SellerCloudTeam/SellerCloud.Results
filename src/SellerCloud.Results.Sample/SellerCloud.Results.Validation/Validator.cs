using SellerCloud.Results.Validation.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SellerCloud.Results.Validation
{
    /// <summary>
    /// The default validator.
    /// </summary>
    /// <seealso cref="IValidator" />
    public class Validator : IValidator
    {
        #region Private Fields and Variables

        private readonly Dictionary<string, IValidationRule> _validationRulesDict = new Dictionary<string, IValidationRule>();
        private readonly IList<ValidationModel> _modelValidators = new List<ValidationModel>();

        private readonly Func<Type, object> _ruleRetrievalFunc;

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="Validator"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public Validator(Func<Type, object> ruleRetrievalFunc)
        {
            _ruleRetrievalFunc = ruleRetrievalFunc;
        }

        /// <see cref="IValidator"/> for more.
        public IValidator AddRule<TParam>(TParam parameters, Action<ValidatorSetter<TParam>> validatorSetter, bool canBreak = true)
        {
            ValidatorSetter<TParam> setter = new ValidatorSetter<TParam>();

            validatorSetter(setter);

            return AddRuleType(parameters, setter.RuleType, canBreak);
        }

        /// <see cref="IValidator"/> for more.
        public IValidator AddRule<TRule>(dynamic parameters) =>
            AddRuleType(parameters, typeof(TRule), true);

        /// <see cref="IValidator"/> for more.
        public IValidator AddRule<TRule>(dynamic parameters, bool canBrake)
            where TRule : IValidationRule
                => AddRuleType(parameters, typeof(TRule), canBrake);

        /// <see cref="IValidator"/> for more.
        public IValidator AddRuleType(object parameters, Type ruleType, bool canBreak)
        {
            string ruleKey = GetOrAddKey(ruleType);

            _modelValidators.Add(new ValidationModel(ruleKey, parameters, canBreak));

            return this;
        }

        /// <see cref="IValidator"/> for more.
        public async Task<ValidationResult> ValidateAsync()
        {
            ValidationResult result = new ValidationResult();
            foreach (var rule in _modelValidators)
            {
                IValidationRule instance = _validationRulesDict[rule.ValidationKey];
                bool isValid = await instance.Validate(rule.Parameters);
                if (!isValid)
                {
                    result.Add(instance.Error);
                    if (rule.CanBreak)
                    {
                        break;
                    }
                }
            }

            _modelValidators.Clear();

            return result;
        }

        #endregion

        #region Private Methods

        private string GetOrAddKey(Type typeOfTheRule)
        {
            string ruleKey = typeOfTheRule.ToString();
            if (!_validationRulesDict.ContainsKey(ruleKey))
            {
                var validationRule = _ruleRetrievalFunc(typeOfTheRule) as IValidationRule;
                _validationRulesDict.Add(ruleKey, validationRule);
            }

            return ruleKey;
        }

        #endregion
    }
}
