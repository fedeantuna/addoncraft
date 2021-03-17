using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AddonCraft.Domain.Bases;
using AddonCraft.Domain.Enums;
using AddonCraft.Domain.ValueObjects;

namespace AddonCraft.Domain.Entities
{
    /// <inheritdoc/>
    /// <summary>
    /// Represents an addon.
    /// </summary>
    public class Addon : Entity
    {
        private readonly ICollection<Module> _modules;

        /// <summary>
        /// Private constructor for Entity Framework
        /// </summary>
        // ExcludeFromCodeCoverage: There is no value in testing this.
        [ExcludeFromCodeCoverage]
        private Addon()
        {
        }

        /// <summary>
        /// Initializes the addon with the specified name, version, package, game version flavor and release type.
        /// </summary>
        /// <param name="name">The specified name.</param>
        /// <param name="version">The specified version.</param>
        /// <param name="metadata">The specified package.</param>
        /// <param name="gameFlavor">The specified game version flavor.</param>
        /// <param name="releaseType">The specified release type.</param>
        public Addon(String name, String version, Metadata metadata, GameFlavor gameFlavor, ReleaseType releaseType)
        {
            this.Name = name;
            this.Version = version;
            this.Metadata = metadata;
            this.GameFlavor = gameFlavor;
            this.ReleaseType = releaseType;

            this._modules = new List<Module>();
        }

        /// <summary>
        /// Addon's name.
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Addon's version.
        /// </summary>
        public String Version { get; private set; }

        /// <summary>
        /// Addon's game version flavor.
        /// </summary>
        public GameFlavor GameFlavor { get; private set; }

        /// <summary>
        /// Addon's release type.
        /// </summary>
        public ReleaseType ReleaseType { get; private set; }

        /// <summary>
        /// Addon's metadata.
        /// </summary>
        public Metadata Metadata { get; private set; }

        /// <summary>
        /// Addon's modules.
        /// </summary>
        public IEnumerable<Module> Modules => this._modules;

        /// <summary>
        /// Adds a specified module to the addon.
        /// </summary>
        /// <param name="module">The specified module.</param>
        public void AddModule(Module module)
        {
            if (this._modules.All(m => m.Name != module.Name))
            {
                this._modules.Add(module);
            }
        }

        /// <summary>
        /// Removes a specified module from the addon.
        /// </summary>
        /// <param name="name">The specified module name.</param>
        public void RemoveModule(String name)
        {
            var module = this._modules.SingleOrDefault(m => m.Name == name);

            if (module != null)
            {
                this._modules.Remove(module);
            }
        }

        /// <summary>
        /// Updates the addon's name to the specified one.
        /// </summary>
        /// <param name="name">The specified name.</param>
        public void UpdateName(String name) => this.Name = name;

        /// <summary>
        /// Updates the addon's version to the specified one.
        /// </summary>
        /// <param name="version">The specified version.</param>
        public void UpdateVersion(String version) => this.Version = version;

        /// <summary>
        /// Updates the addon's release type to the specified one.
        /// </summary>
        /// <param name="releaseType">The specified release type.</param>
        public void UpdateReleaseType(ReleaseType releaseType) => this.ReleaseType = releaseType;
    }
}