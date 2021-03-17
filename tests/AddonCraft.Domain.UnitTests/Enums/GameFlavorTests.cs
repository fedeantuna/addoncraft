using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.Enums;
using Xunit;

namespace AddonCraft.Domain.UnitTests.Enums
{
    [ExcludeFromCodeCoverage]
    public class GameFlavorTests
    {
        [Fact]
        public void ToString_Returns_GameFlavorName()
        {
            // Arrange
            const String retailName = "Retail";
            const String classicName = "Classic";

            // Act
            var retailGameFlavorName = GameFlavor.Retail.ToString();
            var classicGameFlavorName = GameFlavor.Classic.ToString();

            // Assert
            Assert.Equal(retailName, retailGameFlavorName);
            Assert.Equal(classicName, classicGameFlavorName);
        }

        [Fact]
        public void ToCurseforgeCode_Returns_CurseforgeGameFlavorCode()
        {
            // Arrange
            const String retailCurseforgeCode = "wow_retail";
            const String classicCurseforgeCode = "wow_classic";

            // Act
            var retailGameFlavorCurseforgeCode = GameFlavor.Retail.ToCurseforgeCode();
            var classicGameFlavorCurseforgeCode = GameFlavor.Classic.ToCurseforgeCode();

            // Assert
            Assert.Equal(retailCurseforgeCode, retailGameFlavorCurseforgeCode);
            Assert.Equal(classicCurseforgeCode, classicGameFlavorCurseforgeCode);
        }

        [Fact]
        public void CanBeImplicitCastedToTheCorrespondingEnumValue()
        {
            // Arrange
            var retailGameFlavor = GameFlavor.Retail;
            var classicGameFlavor = GameFlavor.Classic;
            
            var retailEnum = GameFlavor.GameFlavorEnum.Retail;
            var classicEnum = GameFlavor.GameFlavorEnum.Classic;

            // Act
            var castedRetailEnum = (GameFlavor.GameFlavorEnum)retailGameFlavor;
            var castedClassicEnum = (GameFlavor.GameFlavorEnum)classicGameFlavor;

            // Assert
            Assert.Equal(retailEnum, castedRetailEnum);
            Assert.Equal(classicEnum, castedClassicEnum);
        }

        [Fact]
        public void FromCode_Returns_CorrespondingGameFlavor()
        {
            // Arrange
            const String retailCode = "wow_retail";
            const String classicCode = "wow_classic";

            var retailGameFlavor = GameFlavor.Retail;
            var classicGameFlavor = GameFlavor.Classic;

            // Act
            var retail = GameFlavor.FromCode(retailCode);
            var classic = GameFlavor.FromCode(classicCode);

            // Assert
            Assert.Equal(retailGameFlavor, retail);
            Assert.Equal(classicGameFlavor, classic);
        }

        [Fact]
        public void FromEnum_Returns_CorrespondingGameFlavor()
        {
            // Arrange
            const GameFlavor.GameFlavorEnum retailEnum = GameFlavor.GameFlavorEnum.Retail;
            const GameFlavor.GameFlavorEnum classicEnum = GameFlavor.GameFlavorEnum.Classic;

            var retailGameFlavor = GameFlavor.Retail;
            var classicGameFlavor = GameFlavor.Classic;

            // Act
            var retail = GameFlavor.FromEnum(retailEnum);
            var classic = GameFlavor.FromEnum(classicEnum);

            // Assert
            Assert.Equal(retailGameFlavor, retail);
            Assert.Equal(classicGameFlavor, classic);
        }
    }
}