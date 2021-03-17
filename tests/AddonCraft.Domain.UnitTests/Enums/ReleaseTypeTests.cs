using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.Enums;
using Xunit;

namespace AddonCraft.Domain.UnitTests.Enums
{
    [ExcludeFromCodeCoverage]
    public class ReleaseTypeTests
    {
        [Fact]
        public void ToString_Returns_ReleaseTypeName()
        {
            // Arrange
            const String stableName = "Stable";
            const String betaName = "Beta";
            const String alphaName = "Alpha";

            // Act
            var stableReleaseTypeName = ReleaseType.Stable.ToString();
            var betaReleaseTypeName = ReleaseType.Beta.ToString();
            var alphaReleaseTypeName = ReleaseType.Alpha.ToString();

            // Assert
            Assert.Equal(stableName, stableReleaseTypeName);
            Assert.Equal(betaName, betaReleaseTypeName);
            Assert.Equal(alphaName, alphaReleaseTypeName);
        }

        [Fact]
        public void ToCurseforgeCode_Returns_CurseforgeReleaseTypeCode()
        {
            // Arrange
            var stableCurseforgeCode = 1;
            var betaCurseforgeCode = 2;
            var alphaCurseforgeCode = 3;

            // Act
            var stableReleaseTypeCurseforgeCode = ReleaseType.Stable.ToCurseforgeCode();
            var betaReleaseTypeCurseforgeCode = ReleaseType.Beta.ToCurseforgeCode();
            var alphaReleaseTypeCurseforgeCode = ReleaseType.Alpha.ToCurseforgeCode();

            // Assert
            Assert.Equal(stableCurseforgeCode, stableReleaseTypeCurseforgeCode);
            Assert.Equal(betaCurseforgeCode, betaReleaseTypeCurseforgeCode);
            Assert.Equal(alphaCurseforgeCode, alphaReleaseTypeCurseforgeCode);
        }

        [Fact]
        public void CanBeImplicitCastedToTheCorrespondingEnumValue()
        {
            // Arrange
            var stableReleaseType = ReleaseType.Stable;
            var betaReleaseType = ReleaseType.Beta;
            var alphaReleaseType = ReleaseType.Alpha;
            
            var stableEnum = ReleaseType.ReleaseTypeEnum.Stable;
            var betaEnum = ReleaseType.ReleaseTypeEnum.Beta;
            var alphaEnum = ReleaseType.ReleaseTypeEnum.Alpha;

            // Act
            var castedStableEnum = (ReleaseType.ReleaseTypeEnum)stableReleaseType;
            var castedBetaEnum = (ReleaseType.ReleaseTypeEnum)betaReleaseType;
            var castedAlphaEnum = (ReleaseType.ReleaseTypeEnum)alphaReleaseType;

            // Assert
            Assert.Equal(stableEnum, castedStableEnum);
            Assert.Equal(betaEnum, castedBetaEnum);
            Assert.Equal(alphaEnum, castedAlphaEnum);
        }

        [Fact]
        public void FromEnum_Returns_CorrespondingReleaseType()
        {
            // Arrange
            const ReleaseType.ReleaseTypeEnum stableEnum = ReleaseType.ReleaseTypeEnum.Stable;
            const ReleaseType.ReleaseTypeEnum betaEnum = ReleaseType.ReleaseTypeEnum.Beta;
            const ReleaseType.ReleaseTypeEnum alphaEnum = ReleaseType.ReleaseTypeEnum.Alpha;
            
            var stableReleaseType = ReleaseType.Stable;
            var betaReleaseType = ReleaseType.Beta;
            var alphaReleaseType = ReleaseType.Alpha;

            // Act
            var stable = ReleaseType.FromEnum(stableEnum);
            var beta = ReleaseType.FromEnum(betaEnum);
            var alpha = ReleaseType.FromEnum(alphaEnum);

            // Assert
            Assert.Equal(stableReleaseType, stable);
            Assert.Equal(betaReleaseType, beta);
            Assert.Equal(alphaReleaseType, alpha);
        }
    }
}