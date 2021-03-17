using System.Diagnostics.CodeAnalysis;
using AddonCraft.Application.Common.Mappings;
using AddonCraft.Application.UnitTests.Mocks;
using AutoMapper;
using Xunit;

namespace AddonCraft.Application.UnitTests.Common.Mappings
{
    [ExcludeFromCodeCoverage]
    public class MappingTests
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            this._configurationProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            this._mapper = this._configurationProvider.CreateMapper();
        }

        [Fact]
        public void MappingConfigurationIsValid() =>
            // Act
            // Arrange
            // Assert
            this._configurationProvider.AssertConfigurationIsValid();
    }
}