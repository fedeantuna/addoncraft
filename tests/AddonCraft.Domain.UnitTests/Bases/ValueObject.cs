using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.UnitTests.Mocks;
using Xunit;

namespace AddonCraft.Domain.UnitTests.Bases
{
    [ExcludeFromCodeCoverage]
    public class ValueObjectTests
    {
        [Fact]
        public void GetHashCode_WhenPropertiesAreNull_ReturnsZero()
        {
            // Arrange
            var sut = new ValueObjectMock
            {
                TestNullableInt = null
            };

            // Act
            var result = sut.GetHashCode();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetHashCode_WhenPropertiesAreNotNull_ReturnsXOROfEachPropertyHashCode()
        {
            // Arrange
            var testNumber = new Random().Next();
            const String testString = "Test String";

            var sut = new ValueObjectMock
            {
                TestNullableInt = testNumber,
                TestString = testString
            };

            var testNumberHashCode = testNumber.GetHashCode();
            var testStringHashCode = testString.GetHashCode();
            var expectedHashCode = testNumberHashCode ^ testStringHashCode;

            // Act
            var result = sut.GetHashCode();

            // Assert
            Assert.Equal(expectedHashCode, result);
        }

        [Fact]
        public void GetHashCode_ForEquivalentValueObjects_ReturnsSameHashCodes()
        {
            // Arrange
            const Int32 differentiator = 1;

            var sutA = new ValueObjectMock
            {
                TestNullableInt = differentiator
            };
            var sutB = new ValueObjectMock
            {
                TestNullableInt = differentiator
            };

            // Act
            var hashCodeA = sutA.GetHashCode();
            var hashCodeB = sutB.GetHashCode();

            // Assert
            Assert.Equal(hashCodeA, hashCodeB);
        }

        [Fact]
        public void GetHashCode_ForDifferentValueObjects_ReturnsDifferentHashCodes()
        {
            // Arrange
            const Int32 differentiatorA = 1;
            const Int32 differentiatorB = 2;

            var sutA = new ValueObjectMock
            {
                TestNullableInt = differentiatorA
            };
            var sutB = new ValueObjectMock
            {
                TestNullableInt = differentiatorB
            };

            // Act
            var hashCodeA = sutA.GetHashCode();
            var hashCodeB = sutB.GetHashCode();

            // Assert
            Assert.NotEqual(hashCodeA, hashCodeB);
        }

        [Fact]
        public void Equals_ForEquivalentValueObjects_ReturnsTrue()
        {
            // Arrange
            const Int32 differentiator = 1;

            var sutA = new ValueObjectMock
            {
                TestNullableInt = differentiator
            };
            var sutB = new ValueObjectMock
            {
                TestNullableInt = differentiator
            };

            // Act
            var aEqualsB = sutA.Equals(sutB);
            var bEqualsA = sutB.Equals(sutA);

            // Assert
            Assert.True(aEqualsB);
            Assert.True(bEqualsA);
        }

        [Fact]
        public void Equals_ForDifferentValueObjects_ReturnsFalse()
        {
            // Arrange
            const Int32 differentiatorA = 1;
            const Int32 differentiatorB = 2;

            var sutA = new ValueObjectMock
            {
                TestNullableInt = differentiatorA
            };
            var sutB = new ValueObjectMock
            {
                TestNullableInt = differentiatorB
            };

            // Act
            var aEqualsB = sutA.Equals(sutB);
            var bEqualsA = sutB.Equals(sutA);

            // Assert
            Assert.False(aEqualsB);
            Assert.False(bEqualsA);
        }

        [Fact]
        public void Equals_WhenComparingWithNull_ReturnsFalse()
        {
            // Arrange
            var sut = new ValueObjectMock();

            // Act
            var result = sut.Equals(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_WhenComparingWithDifferentType_ReturnsFalse()
        {
            // Arrange
            var differentType = new Object();

            var sut = new ValueObjectMock();

            // Act
            var result = sut.Equals(differentType);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void EqualOperator_ForEquivalentValueObjects_ReturnsTrue()
        {
            // Arrange
            const Int32 differentiator = 1;

            var sutA = new ValueObjectMock
            {
                TestNullableInt = differentiator
            };
            var sutB = new ValueObjectMock
            {
                TestNullableInt = differentiator
            };

            // Act
            var aEqualsB = sutA == sutB;
            var bEqualsA = sutB == sutA;

            // Assert
            Assert.True(aEqualsB);
            Assert.True(bEqualsA);
        }

        [Fact]
        public void EqualOperator_ForDifferentValueObjects_ReturnsFalse()
        {
            // Arrange
            const Int32 differentiatorA = 1;
            const Int32 differentiatorB = 2;

            var sutA = new ValueObjectMock
            {
                TestNullableInt = differentiatorA
            };
            var sutB = new ValueObjectMock
            {
                TestNullableInt = differentiatorB
            };

            // Act
            var aEqualsB = sutA == sutB;
            var bEqualsA = sutB == sutA;

            // Assert
            Assert.False(aEqualsB);
            Assert.False(bEqualsA);
        }

        [Fact]
        public void NotEqualOperator_ForDifferentValueObjects_ReturnsTrue()
        {
            // Arrange
            const Int32 differentiatorA = 1;
            const Int32 differentiatorB = 2;

            var sutA = new ValueObjectMock
            {
                TestNullableInt = differentiatorA
            };
            var sutB = new ValueObjectMock
            {
                TestNullableInt = differentiatorB
            };

            // Act
            var aEqualsB = sutA != sutB;
            var bEqualsA = sutB != sutA;

            // Assert
            Assert.True(aEqualsB);
            Assert.True(bEqualsA);
        }

        [Fact]
        public void NotEqualOperator_ForEquivalentValueObjects_ReturnsFalse()
        {
            // Arrange
            const Int32 differentiator = 1;

            var sutA = new ValueObjectMock
            {
                TestNullableInt = differentiator
            };
            var sutB = new ValueObjectMock
            {
                TestNullableInt = differentiator
            };

            // Act
            var aEqualsB = sutA != sutB;
            var bEqualsA = sutB != sutA;

            // Assert
            Assert.False(aEqualsB);
            Assert.False(bEqualsA);
        }
    }
}