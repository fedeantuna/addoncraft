using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.Entities;
using Xunit;

namespace AddonCraft.Domain.UnitTests.Entities
{
    [ExcludeFromCodeCoverage]
    public class MetadataTests
    {
        [Fact]
        public void WhenPackageIsCreated_IdIsSetToARandomGuidAndNameAndExternalIdAreSetToSpecifiedValues()
        {
            // Arrange
            const String packageName = "Test Package Name";
            var externalId = new Random().Next();

            // Act
            var sut = new Metadata(externalId, packageName);

            // Assert
            Assert.NotEqual(Guid.Empty, sut.Id);
            Assert.Equal(packageName, sut.PackageName);
            Assert.Equal(externalId, sut.ExternalId);
        }
    }
}