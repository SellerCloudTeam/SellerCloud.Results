using System;
using NUnit.Framework;

namespace SellerCloud.Results.Tests.Extensions
{
    [TestFixture]
    public class ResultExtensionsTests
    {
        public ResultExtensionsTests()
        {
        }

        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("")]
        [TestCase(null)]
        public void ToFullErrorString_EmptyOrNullString_ReturnsSameMessage(string message)
        {
            // Arrange
            var errorResult = ResultFactory.Error(message);

            // Act
            var fullErrorResult = errorResult.ToFullErrorString();

            // Assert
            Assert.AreEqual(message, fullErrorResult);
        }

        [TestCase("testMessage", "testSource")]
        public void ToFullErrorString_EmptyOrNullString_ReturnsSameMessage(string message, string source)
        {
            // Arrange
            var errorResult = ResultFactory.Error<string>(message, source);

            // Act
            var fullErrorResult = errorResult.ToFullErrorString();

            // Assert
            Assert.AreEqual($"{message}\r\n\r\n{source}", fullErrorResult);
        }

        [TestCase("testMessage", "testSource")]
        public void ResolveOrThrow_Error_ShouldThrow(string message, string source)
        {
            // Arrange
            var errorResult = ResultFactory.Error<string>(message, source);

            // Act-Assert
            Assert.Throws<ApplicationException>(() =>
            {
                var fullErrorResult = errorResult.ResolveOrThrow();
            });
        }

        [TestCase("testMessage")]
        public void ResolveOrThrow_Success_ShouldNotThrow(string data)
        {
            // Arrange
            var errorResult = ResultFactory.Success(data);

            // Act-Assert
            Assert.DoesNotThrow(() =>
            {
                var fullErrorResult = errorResult.ResolveOrThrow();
            });
        }
    }
}
