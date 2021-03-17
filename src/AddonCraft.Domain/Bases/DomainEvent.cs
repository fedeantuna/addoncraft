using System;
using AddonCraft.Domain.Services;

namespace AddonCraft.Domain.Bases
{
    /// <summary>
    /// Base for domain events.
    /// </summary>
    public abstract class DomainEvent
    {
        /// <summary>
        /// Initializes the domain event.
        /// </summary>
        /// <param name="timeService">The Time Service dependency.</param>
        public DomainEvent(ITimeService timeService)
        {
            this.OccurredAt = timeService.UtcNow;
        }

        /// <summary>
        /// Exact time when the event occurred.
        /// </summary>
        public DateTimeOffset OccurredAt { get; protected set; }
    }
}