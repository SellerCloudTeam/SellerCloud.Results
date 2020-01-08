using System;
using NUnit.Framework;

namespace SellerCloud.Results.Tests.Extensions
{
    [TestFixture]
    public class ExceptionExtensionsTests
    {
        [Test]
        public void AsResult_Exception_ReturnsUnsuccessFulResult()
        {
            // Arrange
            var exception = new Exception();

            // Act
            var errorResult = exception.AsResult();

            // Assert
            Assert.AreEqual(false, errorResult.IsSuccessful);
        }

        [Test]
        public void AsResult_Exception_ReturnsUnsuccessFulResultWithValue()
        {
            // Arrange
            var exception = new Exception();

            // Act
            var errorResult = exception.AsResult<string>();

            // Assert
            Assert.AreEqual(false, errorResult.IsSuccessful);
        }
    }
}
