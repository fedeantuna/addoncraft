using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.Services;
using AddonCraft.Domain.UnitTests.Mocks;
using Moq;
using Xunit;

namespace AddonCraft.Domain.UnitTests.Bases
{
    [ExcludeFromCodeCoverage]
    public class DomainEventTests
    {
        private readonly Mock<ITimeService> _timeServiceMock;

        public DomainEventTests()
        {
            this._timeServiceMock = new Mock<ITimeService>();
        }

        [Fact]
        public void WhenDomainEventIsCreated_OccurredAtIsSetWithTheExactTimeAtWhichTheCreationHappens()
        {
            // Arrange
            var now = DateTime.UtcNow;
            this._timeServiceMock.SetupGet(tsm => tsm.UtcNow).Returns(now);

            // Act
            var sut = new DomainEventMock(this._timeServiceMock.Object);

            // Assert
            Assert.Equal(now, sut.OccurredAt);
        }
    }
}