using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.Bases;

namespace AddonCraft.Application.UnitTests.Mocks
{
    [ExcludeFromCodeCoverage]
    public class EntityMock : Entity
    {
        public String TestText { get; set; }
        public Boolean TestFlag { get; set; }
        public Char TestChar { get; set; }
    }
}