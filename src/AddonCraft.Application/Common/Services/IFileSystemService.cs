using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace AddonCraft.Application.Common.Services
{
    /// <summary>
    /// Defines a contract for interaction with the file system.
    /// </summary>
    public interface IFileSystemService
    {
        /// <summary>
        /// Extracts the content from <paramref name="zipFileContent"/> into <paramref name="destination"/>.
        /// </summary>
        /// <param name="zipFileContent">The content of the zip file as a <see cref="byte"/> array.</param>
        /// <param name="destination">The directory where the zip file will be extracted.</param>
        /// <returns>The list of directories, as a string enumerable, at the root level of the zip file.</returns>
        /// <exception cref="ArgumentException">The stream created from <paramref name="zipFileContent"/> is already closed, or the capabilities of the stream do not match the <see cref="ZipArchiveMode.Read"/>. -or- <paramref name="destination"/> is a zero-length string, contains only whitespace, or contains one or more invalid characters as defined by <see cref="Path.InvalidPathChars"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="zipFileContent"/> is null. -or- <paramref name="destination"/> is null.</exception>
        /// <exception cref="System.IO.InvalidDataException">The contents of the <paramref name="zipFileContent"/> could not be interpreted as a zip archive. -or- The zip archive is corrupt, and its entries cannot be retrieved. -or- A <see cref="ZipArchiveEntry"/> was not found or was corrupt. -or- A <see cref="ZipArchiveEntry"/> has been compressed using a compression method that is not supported.</exception>
        /// <exception cref="NotSupportedException">The zip archive does not support reading.</exception>
        /// <exception cref="NullReferenceException">The zip archive contains a null entry.</exception>
        /// <exception cref="System.IO.PathTooLongException">The specified <paramref name="destination"/>, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">The specified <paramref name="destination"/> is invalid, (for example, it is on an unmapped drive).</exception>
        /// <exception cref="System.IO.IOException">The name of a <see cref="System.IO.Compression.ZipArchiveEntry"/> is zero-length, contains only whitespace, or contains one or more invalid characters as defined by <see cref="Path.InvalidPathChars"/> -or- Extracting a <see cref="ZipArchiveEntry"/> would have resulted in a destination file that is outside <paramref name="destination"/> (for example, if the entry name contains parent directory accessors). -or- A <see cref="ZipArchiveEntry"/> has the same name as an already extracted entry from the same archive.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException"><paramref name="destination"/> is in an invalid format.</exception>
        IEnumerable<String> ExtractZipFile(Byte[] zipFileContent, String destination);
    }
}