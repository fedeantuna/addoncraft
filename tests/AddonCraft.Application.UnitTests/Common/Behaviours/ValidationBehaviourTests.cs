using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AddonCraft.Application.Common.Behaviours;
using AddonCraft.Application.UnitTests.Mocks;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Xunit;

namespace AddonCraft.Application.UnitTests.Common.Behaviours
{
    [ExcludeFromCodeCoverage]
    public class ValidationBehaviourTests
    {
        private readonly String _handlerResponse;
        private readonly RequestMock _request;
        private readonly CancellationToken _cancellationToken;
        private readonly Mock<IValidator<RequestMock>> _textValidatorMock;
        private readonly IEnumerable<IValidator<RequestMock>> _validators;

        public ValidationBehaviourTests()
        {
            this._handlerResponse = "Test Handler";
            this._request = new RequestMock
            {
                Id = 0,
                SomeText = "Test Text"
            };
            this._cancellationToken = default;
            this._textValidatorMock = new Mock<IValidator<RequestMock>>();
            
            var idValidatorMock = new Mock<IValidator<RequestMock>>();
            
            this._validators = new List<IValidator<RequestMock>>
            {
                idValidatorMock.Object,
                this._textValidatorMock.Object
            };
            
            idValidatorMock.Setup(v =>
                    v.ValidateAsync(It.Is<ValidationContext<RequestMock>>(c =>
                            c.InstanceToValidate.Id == this._request.Id &&
                            c.InstanceToValidate.SomeText == this._request.SomeText),
                        this._cancellationToken))
                .ReturnsAsync(new ValidationResult());
        }

        [Fact]
        public async Task Handle_WhenThereAreNoValidators_ReturnsHandlerResult()
        {
            // Arrange
            var sut = new ValidationBehaviour<RequestMock, String>(Enumerable.Empty<IValidator<RequestMock>>());

            // Act
            var result = await sut.Handle(this._request, this._cancellationToken, Handler);

            // Assert
            Assert.Equal(this._handlerResponse, result);
        }

        [Fact]
        public async Task Handle_WhenThereAreValidatorsAndNoFailures_ReturnsHandlerResult()
        {
            // Arrange
            this._textValidatorMock.Setup(v =>
                    v.ValidateAsync(It.Is<ValidationContext<RequestMock>>(c =>
                            c.InstanceToValidate.Id == this._request.Id &&
                            c.InstanceToValidate.SomeText == this._request.SomeText),
                        this._cancellationToken))
                .ReturnsAsync(new ValidationResult());

            var sut = new ValidationBehaviour<RequestMock, String>(this._validators);

            // Act
            var result = await sut.Handle(this._request, this._cancellationToken, Handler);

            // Assert
            Assert.Equal(this._handlerResponse, result);
        }

        [Fact]
        public async Task Handle_WhenThereAreValidatorsAndFailures_ThrowsValidationException()
        {
            // Arrange
            const String failureMessage = "Test Failure";
            var failures = new List<ValidationFailure>
            {
                new(nameof(RequestMock.SomeText), failureMessage)
            };
            this._textValidatorMock.Setup(v =>
                    v.ValidateAsync(It.Is<ValidationContext<RequestMock>>(c =>
                            c.InstanceToValidate.Id == this._request.Id &&
                            c.InstanceToValidate.SomeText == this._request.SomeText),
                        this._cancellationToken))
                .ReturnsAsync(new ValidationResult(failures));

            var sut = new ValidationBehaviour<RequestMock, String>(this._validators);

            // Act
            // Assert
            var result =
                await Assert.ThrowsAsync<ValidationException>(() =>
                    sut.Handle(this._request, this._cancellationToken, Handler));
            Assert.Contains(failureMessage, result.Message);
        }

        private async Task<String> Handler() => await Task.FromResult(this._handlerResponse);
    }
}