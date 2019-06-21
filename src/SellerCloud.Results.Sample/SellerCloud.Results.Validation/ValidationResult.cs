using System.Collections.Generic;

namespace SellerCloud.Results.Validation
{
    /// <summary>
    /// A model validation result.
    /// </summary>
    public class ValidationResult : List<ValidationError>
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="ValidationResult"/> is valid.
        /// </summary>
        public bool Valid
        {
            get
            {
                return Count == 0;
            }
        }
    }
}
