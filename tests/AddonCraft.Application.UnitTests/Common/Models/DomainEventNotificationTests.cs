using System.Diagnostics.CodeAnalysis;
using AddonCraft.Application.Common.Models;
using AddonCraft.Application.UnitTests.Mocks;
using AddonCraft.Domain.Services;
using Moq;
using Xunit;

namespace AddonCraft.Application.UnitTests.Common.Models
{
    [ExcludeFromCodeCoverage]
    public class DomainEventNotificationTests
    {
        private readonly Mock<ITimeService> _timeServiceMock;

        public DomainEventNotificationTests()
        {
            this._timeServiceMock = new Mock<ITimeService>();
        }

        [Fact]
        public void WhenDomainEventNotificationIsCreated_DomainEventIsSet()
        {
            // Arrange
            var fakeDomainEvent = new DomainEventMock(this._timeServiceMock.Object);

            // Act
            var sut = new DomainEventNotification<DomainEventMock>(fakeDomainEvent);

            // Result
            Assert.Equal(fakeDomainEvent, sut.DomainEvent);
        }
    }
}