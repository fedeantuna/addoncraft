using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.ValueObjects;
using Xunit;

namespace AddonCraft.Domain.UnitTests.ValueObjects
{
    [ExcludeFromCodeCoverage]
    public class ModuleTests
    {
        [Fact]
        public void WhenModuleIsCreated_NameIsSetToSpecifiedValue()
        {
            // Arrange
            const String name = "Test Module Name";

            // Act
            var module = new Module(name);

            // Assert
            Assert.Equal(name, module.Name);
        }
    }
}