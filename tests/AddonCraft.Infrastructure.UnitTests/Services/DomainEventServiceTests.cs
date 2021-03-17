using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AddonCraft.Application.Common.Models;
using AddonCraft.Domain.Services;
using AddonCraft.Infrastructure.Services;
using AddonCraft.Infrastructure.UnitTests.Mocks;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AddonCraft.Infrastructure.UnitTests.Services
{
    [ExcludeFromCodeCoverage]
    public class DomainEventServiceTests
    {
        private readonly Mock<ITimeService> _timeServiceMock;
        private readonly Mock<ILogger<DomainEventService>> _loggerMock;
        private readonly Mock<IMediator> _mediatorMock;

        private readonly DomainEventService _sut;

        public DomainEventServiceTests()
        {
            this._timeServiceMock = new Mock<ITimeService>();
            this._loggerMock = new Mock<ILogger<DomainEventService>>();
            this._mediatorMock = new Mock<IMediator>();

            this._sut = new DomainEventService(this._timeServiceMock.Object,
                this._mediatorMock.Object,
                this._loggerMock.Object);
        }

        [Fact]
        public async Task Publish_LogsEventAndPublishesDomainEvent()
        {
            // Arrange
            var domainEvent = new DomainEventMock(this._timeServiceMock.Object);

            const String domainEventName = nameof(DomainEventMock);
            const String message = "Publishing domain event. Event - {0}";

            // Act
            await this._sut.Publish(domainEvent);

            // Assert
            this._loggerMock.Verify(lm => 
                lm.Log(LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString().Contains(String.Format(message, domainEventName))),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, String>)It.IsAny<Object>()),
                Times.Once);
            this._mediatorMock.Verify(mm => mm.Publish(It.Is<INotification>(n => n.GetType() == typeof(DomainEventNotification<DomainEventMock>)), default), Times.Once);
        }

        [Fact]
        public void RaiseEvent_AddsEventToEntity()
        {
            // Arrange
            var entity = new EntityMock();

            var now = DateTime.UtcNow;
            _ = this._timeServiceMock.SetupGet(tsm => tsm.UtcNow).Returns(now);

            // Act
            this._sut.RaiseEvent<DomainEventMock>(entity);

            // Assert
            _ = Assert.Single(entity.DomainEvents);
            _ = Assert.IsType<DomainEventMock>(entity.DomainEvents.Single());
            Assert.Collection(entity.DomainEvents,
                item => Assert.Equal(now, item.OccurredAt));
        }
    }
}