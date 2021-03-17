using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Domain.Bases;

namespace AddonCraft.Domain.Entities
{
    /// <inheritdoc/>
    /// <summary>
    /// Represents information from addons.
    /// </summary>
    public class Metadata : Entity
    {
        /// <summary>
        /// Private constructor for Entity Framework
        /// </summary>
        // ExcludeFromCodeCoverage: There is no value in testing this.
        [ExcludeFromCodeCoverage]
        private Metadata()
        {
        }

        /// <summary>
        /// Initializes metadata with the specified name and external id (the id that the source uses to identify this package).
        /// </summary>
        /// <param name="packageName">The specified name.</param>
        /// <param name="externalId">The specified external id.</param>
        public Metadata(Int32 externalId, String packageName)
        {
            this.ExternalId = externalId;
            this.PackageName = packageName;
        }

        /// <summary>
        /// Package's external id.
        /// </summary>
        public Int32 ExternalId { get; private set; }

        /// <summary>
        /// Package's name.
        /// </summary>
        public String PackageName { get; private set; }
    }
}