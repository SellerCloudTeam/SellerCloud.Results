using Autofac;
using NUnit.Framework;
using SellerCloud.Results.Sample;
using SellerCloud.Results.Sample.Rules;
using SellerCloud.Results.Validation;
using SellerCloud.Results.Validation.Abstractions;
using System;
using System.Threading.Tasks;

namespace SellerCloud.Results.Tests.Sample
{
    [TestFixture]
    public class SampleServiceTests
    {
        private SampleService _service;

        private readonly long invalidId = -100;
        private readonly long invalidClientId = 555;
        private readonly long notExistingId = 1000;

        private readonly long validClientId = 99;
        private readonly long validId = 66;

        [SetUp]
        public void SetUp()
        {
            var container = RegisterAutoFac();

            var validator = container.Resolve<IValidator>();
            _service = new SampleService(validator);
        }

        private IContainer RegisterAutoFac()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<Validator>()
                .As<IValidator>()
                .SingleInstance();

            builder
                .RegisterType<IdentifierShouldBePositive>()
                .As<IValidationRule>()
                .SingleInstance();

            builder.Register<Func<Type, object>>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return typeToResolve => {
                    return context.Resolve(typeToResolve);
                };
            });

            return builder.Build();
        }

        [Test]
        public async Task GetByIdAsync_ValidParameters_NoError()
        {
            var result = await _service.GetByIdAsync(validId, validClientId);

            Assert.True(result.HasValue);
            Assert.True(result.IsSuccessful);
            Assert.AreEqual(100L, result.Value);
            Assert.AreEqual(ResultType.NoError, result.Type);
        }

        [Test]
        public async Task GetByIdAsync_InvalidId_InvalidDataError()
        {
            var result = await _service.GetByIdAsync(invalidId, validClientId);

            Assert.IsFalse(result.IsSuccessful);
            Assert.IsFalse(result.HasValue);
            Assert.AreEqual(default(long), result.Value);
            Assert.AreEqual(ResultType.ValidationError, result.Type);
        }

        [Test]
        public async Task GetByIdAsync_NotFoundClientId_NoData()
        {
            var result = await _service.GetByIdAsync(notExistingId, validClientId);

            Assert.IsTrue(result.IsSuccessful);
            Assert.IsFalse(result.HasValue);
            Assert.AreEqual(default(long), result.Value);
            Assert.AreEqual(ResultType.NoData, result.Type);
        }

        [Test]
        public async Task GetByIdAsync_NotFoundClientId_PermissionError()
        {
            var result = await _service.GetByIdAsync(validId, invalidClientId);

            Assert.IsFalse(result.HasValue);
            Assert.IsFalse(result.IsSuccessful);
            Assert.AreEqual(default(long), result.Value);
            Assert.AreEqual(ResultType.PermissionError, result.Type);
        }

        [Test]
        public async Task GetByIdValidatorAsync_NotFoundClientId_PermissionError()
        {
            var result = await _service.GetByIdValidatorAsync(invalidId, invalidClientId);

            Assert.IsFalse(result.HasValue);
            Assert.IsFalse(result.IsSuccessful);
            Assert.AreEqual(default(long), result.Value);
            Assert.AreEqual(ResultType.PermissionError, result.Type);
        }
    }
}
