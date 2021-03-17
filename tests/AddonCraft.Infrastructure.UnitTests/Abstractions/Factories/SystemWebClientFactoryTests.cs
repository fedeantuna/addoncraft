using System.Diagnostics.CodeAnalysis;
using AddonCraft.Infrastructure.Abstractions;
using AddonCraft.Infrastructure.Abstractions.Factories;
using Xunit;

namespace AddonCraft.Infrastructure.UnitTests.Abstractions.Factories
{
    [ExcludeFromCodeCoverage]
    public class SystemWebClientFactoryTests
    {
        private readonly SystemWebClientFactory _sut;

        public SystemWebClientFactoryTests()
        {
            this._sut = new SystemWebClientFactory();
        }

        [Fact]
        public void Create_ReturnsSystemWebClient()
        {
            // Arrange

            // Act
            var result = this._sut.Create();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SystemWebClient>(result);
        }
    }
}