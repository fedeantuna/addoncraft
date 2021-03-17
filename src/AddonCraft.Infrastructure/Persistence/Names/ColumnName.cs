using System;

namespace AddonCraft.Infrastructure.Persistence.Names
{
    /// <summary>
    /// Provides the name of the columns for different tables on the database.
    /// </summary>
    public static class ColumnName
    {
        /// <summary>
        /// Column Id
        /// </summary>
        public const String Id = nameof(Id);
        
        /// <summary>
        /// Column AddonId
        /// </summary>
        public const String AddonId = nameof(AddonId);

        /// <summary>
        /// Column Name
        /// </summary>
        public const String Name = nameof(Name);

        /// <summary>
        /// Column GameFlavor
        /// </summary>
        public const String GameFlavor = nameof(GameFlavor);

        /// <summary>
        /// Column ReleaseType
        /// </summary>
        public const String ReleaseType = nameof(ReleaseType);
    }
}