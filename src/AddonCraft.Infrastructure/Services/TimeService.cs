using System;
using AddonCraft.Domain.Services;

namespace AddonCraft.Infrastructure.Services
{
    /// <inheritdoc/>
    /// <summary>
    /// Service that allows DateTime abstraction.
    /// </summary>
    public class TimeService : ITimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}