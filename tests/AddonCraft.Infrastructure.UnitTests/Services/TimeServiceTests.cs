using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Infrastructure.Services;
using Xunit;

namespace AddonCraft.Infrastructure.UnitTests.Services
{
    [ExcludeFromCodeCoverage]
    public class TimeServiceTests
    {
        private readonly TimeService _sut;

        public TimeServiceTests()
        {
            this._sut = new TimeService();
        }

        [Fact]
        public void UtcNow_ReturnsCurrentTime()
        {
            // Arrange
            var now = DateTime.UtcNow;

            // Act
            var result = this._sut.UtcNow;

            // Assert
            Assert.True(result >= now);
            Assert.True(result < now.AddSeconds(1));
        }
    }
}