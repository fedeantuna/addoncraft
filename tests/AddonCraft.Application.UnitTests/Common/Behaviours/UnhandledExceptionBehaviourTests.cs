using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using AddonCraft.Application.Common.Behaviours;
using AddonCraft.Application.UnitTests.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AddonCraft.Application.UnitTests.Common.Behaviours
{
    [ExcludeFromCodeCoverage]
    public class UnhandledExceptionBehaviourTests
    {
        private readonly Mock<ILogger<RequestMock>> _loggerMock;

        private readonly UnhandledExceptionBehaviour<RequestMock, String> _sut;

        public UnhandledExceptionBehaviourTests()
        {
            this._loggerMock = new Mock<ILogger<RequestMock>>();

            this._sut = new UnhandledExceptionBehaviour<RequestMock, String>(this._loggerMock.Object);
        }

        [Fact]
        public async Task Handle_WhenRequestHandlerDelegateIsValid_ReturnsHandlerResult()
        {
            // Arrange
            const String handlerResponse = "Test Handler";
            var request = new RequestMock();
            var cancellationToken = default(CancellationToken);
            async Task<String> Handler() => await Task.FromResult(handlerResponse);

            // Act
            var result = await this._sut.Handle(request, cancellationToken, Handler);

            // Assert
            Assert.Equal(handlerResponse, result);
        }

        [Fact]
        public async Task Handle_WhenRequestHandlerDelegateIsNotValid_LogsExceptionAndRethrows()
        {
            // Arrange
            const String exceptionMessage = "Test Exception";
            var exception = new Exception(exceptionMessage);
            var request = new RequestMock();
            var cancellationToken = default(CancellationToken);
            async Task<String> Handler() => await Task.FromException<String>(exception);
            
            const String errorMessage = "Unhandled Exception for Request {0} {1}";
            const String requestName = nameof(RequestMock);
            
            // Act
            // Assert
            var result = await Assert.ThrowsAsync<Exception>(() => this._sut.Handle(request, cancellationToken, Handler));
            this._loggerMock.Verify(lm => 
                lm.Log(LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString().Contains(String.Format(errorMessage, requestName, request))),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, String>)It.IsAny<Object>()),
                Times.Once);
            Assert.Equal(exceptionMessage, result.Message);
        }
    }
}