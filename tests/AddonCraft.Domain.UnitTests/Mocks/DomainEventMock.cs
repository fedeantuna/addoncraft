using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.Bases;
using AddonCraft.Domain.Services;

namespace AddonCraft.Domain.UnitTests.Mocks
{
    [ExcludeFromCodeCoverage]
    public class DomainEventMock : DomainEvent
    {
        public DomainEventMock(ITimeService timeService)
            : base(timeService)
        {
        }
    }
}