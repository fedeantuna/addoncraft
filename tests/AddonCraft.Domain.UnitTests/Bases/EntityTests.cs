using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.Services;
using AddonCraft.Domain.UnitTests.Mocks;
using Moq;
using Xunit;

namespace AddonCraft.Domain.UnitTests.Bases
{
    [ExcludeFromCodeCoverage]
    public class EntityTests
    {
        private readonly Mock<ITimeService> _timeServiceMock;

        public EntityTests()
        {
            this._timeServiceMock = new Mock<ITimeService>();
        }

        [Fact]
        public void WhenEntityIsCreated_IdIsSetToANewGuid()
        {
            // Arrange
            // Act
            var sut = new EntityMock();

            // Assert
            Assert.NotEqual(Guid.Empty, sut.Id);
        }

        [Fact]
        public void AddDomainEvent_AddsTheDomainEventToTheEntity()
        {
            // Arrange
            var domainEvent = new DomainEventMock(this._timeServiceMock.Object);
            
            var now = DateTime.UtcNow;
            this._timeServiceMock.SetupGet(tsm => tsm.UtcNow).Returns(now);

            var sut = new EntityMock();

            // Act
            sut.AddDomainEvent(domainEvent);

            // Assert
            Assert.Collection(sut.DomainEvents,
                item => Assert.Equal(domainEvent, item));
        }

        [Fact]
        public void SetCreatedAtDate_SetsCreatedAtToASpecificTime()
        {
            // Arrange
            var date = DateTime.UtcNow;

            var sut = new EntityMock();

            // Act
            sut.SetCreatedAtDate(date);

            // Assert
            Assert.Equal(date, sut.CreatedAt);
        }

        [Fact]
        public void SetLastModifiedDate_SetsLastModifiedToASpecificTime()
        {
            // Arrange
            var date = DateTime.UtcNow;

            var sut = new EntityMock();

            // Act
            sut.SetLastModifiedDate(date);

            // Assert
            Assert.Equal(date, sut.LastModified);
        }
    }
}