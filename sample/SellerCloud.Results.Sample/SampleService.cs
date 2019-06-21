using SellerCloud.Results.Sample.Rules;
using SellerCloud.Results.Validation;
using SellerCloud.Results.Validation.Abstractions;
using System.Threading.Tasks;

namespace SellerCloud.Results.Sample
{
    public class SampleService
    {
        private readonly IValidator _validator;

        public SampleService(IValidator validator)
        {
            _validator = validator;
        }

        public Task<Result<long>> GetByIdAsync(long id, long clientId)
        {
            if (id <= 0)
            {
                return Result.ValidationErrorAsync<long>();
            }

            if (clientId != 99)
            {
                return Result.PermissionErrorAsync<long>();
            }

            if (id > 999)
            {
                return Result.NoDataAsync<long>();
            }

            return Result.ResultAsync(100L);
        }

        public async Task<Result<long>> GetByIdValidatorAsync(long id, long clientId)
        {
            ValidationResult validation = await _validator
                .AddRule<IdentifierShouldBePositive>(id)
                .AddRule<IdentifierShouldBePositive>(clientId)
                .ValidateAsync();

            if (!validation.Valid)
            {
                return await Result.ValidationErrorAsync<long>();
            }

            return await Result.ResultAsync(100L);
        }
    }
}
