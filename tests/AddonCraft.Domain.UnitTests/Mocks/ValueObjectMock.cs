using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.Bases;

namespace AddonCraft.Domain.UnitTests.Mocks
{
    [ExcludeFromCodeCoverage]
    public class ValueObjectMock : ValueObject
    {
        public Int32? TestNullableInt { get; init; }

        public String TestString { get; init; }

        protected override IEnumerable<Object> GetEqualityComponents()
        {
            yield return this.TestNullableInt;
            yield return this.TestString;
        }
    }
}