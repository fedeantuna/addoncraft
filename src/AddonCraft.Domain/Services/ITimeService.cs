using System;

namespace AddonCraft.Domain.Services
{
    /// <summary>
    /// Contract that allows DateTime abstraction.
    /// </summary>
    public interface ITimeService
    {
        /// <summary>
        /// Gets a <see cref="DateTime"/> object that is set to the current date and time on this computer,
        /// expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        DateTime UtcNow { get; }
    }
}