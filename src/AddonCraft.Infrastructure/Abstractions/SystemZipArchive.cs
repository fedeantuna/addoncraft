using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Linq;
using AddonCraft.Application.Common.Abstractions;

namespace AddonCraft.Infrastructure.Abstractions
{
    /// <inheritdoc cref="ZipArchive"/>
    /// <summary>
    /// An abstraction from <see cref="ZipArchive"/>.
    /// </summary>
    public class SystemZipArchive : ZipArchive, IZipArchive
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemZipArchive"/> class from the specified stream and with the specified mode.
        /// </summary>
        /// <param name="stream">The input or output stream.</param>
        /// <param name="mode">One of the enumeration values that indicates whether the zip archive is used to read, create, or update entries.</param>
        /// <exception cref="ArgumentException">The <paramref name="stream"/> is already closed, or the capabilities of the <paramref name="stream"/> do not match the mode.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="stream"/> is an invalid value.</exception>
        /// <exception cref="InvalidDataException">The contents of the <paramref name="stream"/> could not be interpreted as a zip archive. -or- <paramref name="mode"/> is <see cref="ZipArchiveMode.Update"/> and an entry is missing from the archive or is corrupt and cannot be read. -or- mode is <see cref="ZipArchiveMode.Update"/> and an entry is too large to fit into memory.</exception>
        public SystemZipArchive(Stream stream, ZipArchiveMode mode)
            : base(stream, mode)
        {
        }

        // ExcludeFromCodeCoverage: This is just a wrapper for an extension method.
        [ExcludeFromCodeCoverage]
        public void ExtractFilesToDirectory(String destination, Boolean overwriteFiles) => this.ExtractToDirectory(destination, overwriteFiles);

        public IEnumerable<String> GetRootEntries() => new HashSet<String>(this.Entries.Select(e => e.FullName.Split('/')[0]));
    }
}