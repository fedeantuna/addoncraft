using System;
using System.Collections.Generic;

namespace AddonCraft.Application.Common.Abstractions
{
    /// <summary>
    /// Defines a contract that allows abstraction from <see cref="System.IO.Compression.ZipArchive"/>.
    /// </summary>
    public interface IZipArchive : IDisposable
    {
        /// <summary>
        /// Extracts all of the files in the archive to a directory on the file system.
        /// </summary>
        /// <param name="destination">The path to the destination directory on the file system. The path can be relative or absolute. A relative path is interpreted as relative to the current working directory.</param>
        /// <param name="overwriteFiles">true to indicate that existing files are to be overwritten; false otherwise.</param>
        /// <exception cref="ArgumentException"><paramref name="destination"/> is a zero-length string, contains only whitespace, or contains one or more invalid characters as defined by <see cref="System.IO.Path.InvalidPathChars"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="destination"/> is null.</exception>
        /// <exception cref="System.IO.PathTooLongException">The specified <paramref name="destination"/>, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">The specified <paramref name="destination"/> is invalid, (for example, it is on an unmapped drive).</exception>
        /// <exception cref="System.IO.IOException">The name of a <see cref="System.IO.Compression.ZipArchiveEntry"/> is zero-length, contains only whitespace, or contains one or more invalid characters as defined by <see cref="System.IO.Path.InvalidPathChars"/> -or- Extracting a <see cref="System.IO.Compression.ZipArchiveEntry"/> would have resulted in a destination file that is outside <paramref name="destination"/> (for example, if the entry name contains parent directory accessors). -or- A <see cref="System.IO.Compression.ZipArchiveEntry"/> has the same name as an already extracted entry from the same archive.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException"><paramref name="destination"/> is in an invalid format.</exception>
        /// <exception cref="System.IO.InvalidDataException">A <see cref="System.IO.Compression.ZipArchiveEntry"/> was not found or was corrupt. -or- A <see cref="System.IO.Compression.ZipArchiveEntry"/> has been compressed using a compression method that is not supported.</exception>
        void ExtractFilesToDirectory(String destination, Boolean overwriteFiles);

        /// <summary>
        /// Gets the collection of entries that are currently in the zip archive at the root level.
        /// </summary>
        /// <returns>The collection of entries that are currently in the zip archive.</returns>
        /// <exception cref="NotSupportedException">The zip archive does not support reading.</exception>
        /// <exception cref="ObjectDisposedException">The zip archive has been disposed.</exception>
        /// <exception cref="System.IO.InvalidDataException">The zip archive is corrupt, and its entries cannot be retrieved.</exception>
        /// <exception cref="NullReferenceException">The zip archive contains a null entry.</exception>
        IEnumerable<String> GetRootEntries();
    }
}