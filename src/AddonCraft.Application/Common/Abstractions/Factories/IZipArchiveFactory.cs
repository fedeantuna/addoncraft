using System.IO;
using System.IO.Compression;

namespace AddonCraft.Application.Common.Abstractions.Factories
{
    /// <summary>
    /// Defines a contract for the <see cref="IZipArchive"/> Factory.
    /// </summary>
    public interface ISystemZipArchiveFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IZipArchive"/> type from the specified stream and with the specified mode.
        /// </summary>
        /// <param name="stream">The input or output stream.</param>
        /// <param name="mode">One of the enumeration values that indicates whether the zip archive is used to read, create, or update entries.</param>
        /// <exception cref="System.ArgumentException">The <paramref name="stream"/> is already closed, or the capabilities of the stream do not match the <paramref name="mode"/>.</exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="stream"/> is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="mode"/> is an invalid value</exception>
        /// <exception cref="InvalidDataException">The contents of the <paramref name="stream"/> could not be interpreted as a zip archive. -or- <paramref name="mode"/> is <see cref="ZipArchiveMode.Update"/> and an entry is missing from the archive or is corrupt and cannot be read. -or- <paramref name="mode"/> is <see cref="ZipArchiveMode.Update"/> and an entry is too large to fit into memory.</exception>
        IZipArchive Create(Stream stream, ZipArchiveMode mode);
    }
}