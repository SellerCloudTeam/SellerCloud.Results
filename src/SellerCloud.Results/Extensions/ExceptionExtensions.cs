using System;

namespace SellerCloud.Results
{
    public static class ExceptionExtensions
    {
        public static Result<T> AsResult<T>(this Exception exception)
        {
            return ResultFactory.Error<T>(exception);
        }
    }
}
