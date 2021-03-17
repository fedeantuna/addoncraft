using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AddonCraft.Domain.Entities;
using AddonCraft.Domain.Enums;
using AddonCraft.Domain.ValueObjects;
using Xunit;

namespace AddonCraft.Domain.UnitTests.Entities
{
    [ExcludeFromCodeCoverage]
    public class AddonTests
    {
        private readonly String _moduleName;
        private readonly Module _module;
        private readonly String _name;
        private readonly String _version;
        private readonly Metadata _metadata;
        private readonly GameFlavor _gameFlavor;
        private readonly ReleaseType _releaseType;
        
        public AddonTests()
        {
            const String packageName = "Test Package Name";
            const Int32 externalId = 1;
            
            this._moduleName = "Test Module Name";
            this._module = new Module(this._moduleName);
            this._name = "Test Addon Name";
            this._version = "0.1.2a";
            this._metadata = new Metadata(externalId, packageName);
            this._gameFlavor = GameFlavor.Retail;
            this._releaseType = ReleaseType.Stable;
        }
        
        [Fact]
        public void WhenAddonIsCreated_IdIsSetToARandomGuidAndPropertiesAreSetToMatchingParameters()
        {
            // Act
            var sut = new Addon(this._name, this._version, this._metadata, this._gameFlavor, this._releaseType);

            // Assert
            Assert.NotEqual(Guid.Empty, sut.Id);
            Assert.Equal(this._name, sut.Name);
            Assert.Equal(this._version, sut.Version);
            Assert.Equal(this._metadata, sut.Metadata);
            Assert.Equal(this._gameFlavor, sut.GameFlavor);
            Assert.Equal(this._releaseType, sut.ReleaseType);
        }

        [Fact]
        public void AddModule_AddsAModuleToTheAddon()
        {
            // Arrange
            var moduleName = "Test Module Name";
            var module = new Module(moduleName);
            
            var sut = new Addon(this._name, this._version, this._metadata, this._gameFlavor, this._releaseType);

            // Act
            sut.AddModule(module);

            // Assert
            Assert.Single(sut.Modules);
            Assert.Equal(module, sut.Modules.Single());
        }

        [Fact]
        public void AddModule_DoesNotAddAModuleToTheAddonIfAlreadyThere()
        {
            // Arrange
            var sut = new Addon(this._name, this._version, this._metadata, this._gameFlavor, this._releaseType);
            sut.AddModule(this._module);

            // Act
            sut.AddModule(this._module);

            // Assert
            Assert.Single(sut.Modules);
            Assert.Equal(this._module, sut.Modules.Single());
        }

        [Fact]
        public void RemoveModule_RemovesAModuleFromTheAddon()
        {
            // Arrange
            var sut = new Addon(this._name, this._version, this._metadata, this._gameFlavor, this._releaseType);
            sut.AddModule(this._module);

            // Act
            sut.RemoveModule(this._moduleName);

            // Assert
            Assert.Empty(sut.Modules);
        }

        [Fact]
        public void RemoveModule_DoesNothingIfModuleIsNotInTheAddon()
        {
            // Arrange
            var sut = new Addon(this._name, this._version, this._metadata, this._gameFlavor, this._releaseType);

            // Act
            sut.RemoveModule(this._moduleName);

            // Assert
            Assert.Empty(sut.Modules);
        }

        [Fact]
        public void UpdateName_UpdatesTheAddonNameToTheSpecifiedOne()
        {
            // Arrange
            const String newName = "New Addon Name";

            var sut = new Addon(this._name, this._version, this._metadata, this._gameFlavor, this._releaseType);

            // Act
            sut.UpdateName(newName);

            // Assert
            Assert.Equal(newName, sut.Name);
        }

        [Fact]
        public void UpdateVersion_UpdatesTheAddonVersionToTheSpecifiedOne()
        {
            // Arrange
            const String newVersion = "3.4.5";
            
            var sut = new Addon(this._name, this._version, this._metadata, this._gameFlavor, this._releaseType);

            // Act
            sut.UpdateVersion(newVersion);

            // Assert
            Assert.Equal(newVersion, sut.Version);
        }

        [Fact]
        public void UpdateReleaseType_UpdatesTheAddonReleaseTypeToTheSpecifiedOne()
        {
            // Arrange
            var newReleaseType = ReleaseType.Alpha;
            var sut = new Addon(this._name, this._version, this._metadata, this._gameFlavor, this._releaseType);

            // Act
            sut.UpdateReleaseType(newReleaseType);

            // Assert
            Assert.Equal(newReleaseType, sut.ReleaseType);
        }
    }
}